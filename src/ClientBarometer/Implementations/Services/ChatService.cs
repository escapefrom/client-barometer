using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClientBarometer.Domain.Constants;
using ClientBarometer.Domain.Models;
using ClientBarometer.Domain.Repositories;
using ClientBarometer.Domain.Services;
using ClientBarometer.Domain.UnitsOfWork;
using ClientBarometer.Hubs;
using ClientBarometer.Implementations.Exceptions;
using ClientBarometer.Implementations.Mappers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Requests = ClientBarometer.Contracts.Requests;
using Responses = ClientBarometer.Contracts.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ClientBarometer.Implementations.Services
{
    public class ChatService : IChatService
    {
        private readonly IMessageReadRepository _messageReadRepository;
        private readonly IChatReadRepository _chatReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IChatUnitOfWork _chatUnitOfWork;
        private readonly IBarometerReadRepository _barometerReadRepository;
        private readonly IBarometerRegisterRepository _barometerRegisterRepository;
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IChatHubService _chatHubService;
        private readonly IBarometerService _barometerService;
        private readonly ISuggestionService _suggestionService;
        private readonly ILogger<ChatService> _logger;

        private static IMapper ChatMapper => Create.ChatMapper.Please;

        public ChatService(
            IMessageReadRepository messageReadRepository,
            IChatReadRepository chatReadRepository,
            IUserReadRepository userReadRepository,
            IChatUnitOfWork chatUnitOfWork,
            IHubContext<ChatHub> chatHubContext,
            IChatHubService chatHubService,
            IBarometerService barometerService,
            ISuggestionService suggestionService,
            ILogger<ChatService> logger)
        {
            _messageReadRepository = messageReadRepository;
            _chatReadRepository = chatReadRepository;
            _userReadRepository = userReadRepository;
            _chatUnitOfWork = chatUnitOfWork;
            _chatHubContext = chatHubContext;
            _chatHubService = chatHubService;
            _barometerService = barometerService;
            _suggestionService = suggestionService;
            _logger = logger;
        }

        public async Task<Responses.Message[]> GetMessages(Guid chatId, int takeLast,
            CancellationToken cancellationToken)
        {
            var messages =
                await _messageReadRepository.GetLastMessages(chatId, takeLast, cancellationToken);
            var users = await _userReadRepository.GetUsers(chatId, cancellationToken);
            var result = ChatMapper.Map<Responses.Message[]>(messages);
            foreach (var mess in result)
                mess.Username = users.FirstOrDefault(user => mess.UserId == user.Id)?.Name ?? "Unknown user";
            return result;
        }

        public async Task<Responses.User> GetUser(Guid chatId, CancellationToken cancellationToken)
        {
            var users = await _userReadRepository.GetUsers(chatId, cancellationToken);
            var user = users.FirstOrDefault(us => us.SourceId != ChatConsts.DEFAULT_USER_SOURCE_ID);
            return ChatMapper.Map<Responses.User>(user);
        }

        public async Task<Responses.Chat[]> GetChats(CancellationToken cancellationToken)
        {
            var chats = ChatMapper.Map<Responses.Chat[]>(await _chatReadRepository.GetChats(0, int.MaxValue, cancellationToken));
            foreach (var chat in chats)
            {
                var users = await _userReadRepository.GetUsers(chat.Id, cancellationToken);
                chat.Username = users.FirstOrDefault(user => user.SourceId != ChatConsts.DEFAULT_USER_SOURCE_ID)?.Name ?? "Unknown user";
            }

            return chats;
        }

        public async Task<Responses.Message> CreateMessage(Requests.CreateMessageRequest request, CancellationToken cancellationToken)
        {
            var newMessage = ChatMapper.Map<Message>(request);

            if (!await _chatReadRepository.Contains(request.ChatId, cancellationToken) &&
                !await _chatReadRepository.Contains(request.ChatSourceId, cancellationToken))
            {
                throw new ChatNotFoundException(request.ChatSourceId);
            }

            var chat = await _chatReadRepository.Get(request.ChatSourceId, cancellationToken);
            if (!await _userReadRepository.Contains(request.UserSourceId, cancellationToken))
            {
                throw new UserNotFoundException(request.UserSourceId);
            }

            var user = await _userReadRepository.Get(request.UserSourceId, cancellationToken);
            var chatId = chat?.Id ?? request.ChatId;

            newMessage.CreatedAt = DateTime.Now;
            newMessage.ChatId = chatId;
            newMessage.UserId = user.Id;
            _chatUnitOfWork.Messages.RegisterNew(newMessage);

            await _chatUnitOfWork.Complete(cancellationToken);

            var message = ChatMapper.Map<Responses.Message>(newMessage);
            message.Username = user.Name;

            var jsonSettings = new JsonSerializerSettings
                {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            var messageJson = JsonConvert.SerializeObject(message, jsonSettings);
            var barometer = await _barometerService.GetValue(chatId, cancellationToken);
            var barometerJson = JsonConvert.SerializeObject(barometer, jsonSettings);
            var suggestions = await _suggestionService.GetSuggestions(chatId, cancellationToken);
            var suggestionsJson = JsonConvert.SerializeObject(suggestions, jsonSettings);

            var clients = await _chatHubService.GetChatSubscribers(chatId);
            foreach (var client in clients)
            {
                await _chatHubContext.Clients.Client(client)
                    .SendAsync("NewMessage", messageJson, cancellationToken);
                await _chatHubContext.Clients.Client(client)
                    .SendAsync("NewBarometer", barometerJson, cancellationToken);
                await _chatHubContext.Clients.Client(client)
                    .SendAsync("NewSuggestions", suggestionsJson, cancellationToken);
            }

            return message;
        }

        public async Task<Responses.Chat> CreateChat(Requests.CreateChatRequest request, CancellationToken cancellationToken)
        {
            var newChat = ChatMapper.Map<Chat>(request);

            if (await _chatReadRepository.Contains(request.SourceId, cancellationToken))
            {
                throw new ChatAlreadyExistsException(request.SourceId);
            }

            newChat.CreatedAt = DateTime.Now;
            _chatUnitOfWork.Chats.RegisterNew(newChat);

            await _chatUnitOfWork.Complete(cancellationToken);

            return ChatMapper.Map<Responses.Chat>(newChat);
        }

        public async Task<Responses.User> CreateUser(Requests.CreateUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = ChatMapper.Map<User>(request);

            if (await _userReadRepository.Contains(request.SourceId, cancellationToken))
            {
                throw new UserAlreadyExistsException(request.SourceId);
            }

            newUser.CreatedAt = DateTime.Now;
            _chatUnitOfWork.Users.RegisterNew(newUser);

            await _chatUnitOfWork.Complete(cancellationToken);

            return ChatMapper.Map<Responses.User>(newUser);
        }

        public async Task RemoveMessages(Guid chatId, CancellationToken cancellationToken)
        {
             _chatUnitOfWork.Messages.RegisterDelete(chatId);
             
             await _chatUnitOfWork.Complete(cancellationToken);
        }
    }
}