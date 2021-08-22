using System;
using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Contracts.Requests;
using ClientBarometer.Domain.Constants;
using ClientBarometer.Domain.Models;
using ClientBarometer.Domain.Repositories;
using ClientBarometer.Domain.Services;
using ClientBarometer.Implementations.Exceptions;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace ClientBarometer.Implementations.Services
{
    public class SourceProcessor : ISourceProcessor
    {
        private readonly IChatService _chatService;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IChatReadRepository _chatReadRepository;
        private readonly TelegramBotClient _tgClient;
        private readonly IAudioService _audioService;
        private readonly ILogger<SourceProcessor> _logger;

        public SourceProcessor(IChatService chatService,
            IUserReadRepository userReadRepository,
            IChatReadRepository chatReadRepository,
            TelegramBotClient tgClient,
            IAudioService audioService,
            ILogger<SourceProcessor> logger)
        {
            _chatService = chatService;
            _userReadRepository = userReadRepository;
            _chatReadRepository = chatReadRepository;
            _tgClient = tgClient;
            _audioService = audioService;
            _logger = logger;
        }
        
        public async Task ProcessToSource(IMessageRequest request, CancellationToken cancellationToken)
        {
            switch(request.Source)
            {
                case ChatConsts.TELEGRAM_SOURCE:
                    await ProcessToTelegram(request, cancellationToken);
                    break;
                case ChatConsts.AUDIO_SOURCE:
                    await ProcessToAudio(request, cancellationToken);
                    break;
                default:
                    throw new SourceNotFoundException(request.Source);
            };
        }
        
        public async Task ProcessFromSource(IMessageRequest request, CancellationToken cancellationToken)
        {
            switch(request.Source)
            {
                case ChatConsts.TELEGRAM_SOURCE:
                    await ProcessFromTelegram(request, cancellationToken);
                    break;
                case ChatConsts.AUDIO_SOURCE:
                    await ProcessFromAudio(request, cancellationToken);
                    break;
                default:
                    throw new SourceNotFoundException(request.Source);
            };
        }

        private async Task ProcessToTelegram(IMessageRequest request, CancellationToken cancellationToken)
        {
            if (request is CreateMessageRequest textRequest)
            {
                await _chatService.CreateMessage(textRequest, cancellationToken);
                var chat = await _chatReadRepository.Get(textRequest.ChatId, cancellationToken);
                await _tgClient.SendTextMessageAsync(chat.SourceId, textRequest.Text,
                    cancellationToken: cancellationToken);
            }
        }

        private async Task ProcessFromTelegram(IMessageRequest request, CancellationToken cancellationToken)
        {
            if (request is CreateMessageRequest textRequest)
            {
                if (!await _chatReadRepository.Contains(textRequest.ChatSourceId, cancellationToken))
                {
                    await CreateChatOnInit(textRequest, cancellationToken);
                }
                if (!await _userReadRepository.Contains(textRequest.UserSourceId, cancellationToken))
                {
                    await CreateUserOnInit(textRequest, cancellationToken);
                }
                await _chatService.CreateMessage(textRequest, cancellationToken);
            }
        }
        
        private async Task ProcessToAudio(IMessageRequest request, CancellationToken cancellationToken)
        {
            if (request is CreateAudioMessageRequest audioRequest)
            {
                var textRequest = await _audioService.GetTextMessage(audioRequest, cancellationToken);
                if (!await _chatReadRepository.Contains(audioRequest.ChatSourceId, cancellationToken))
                {
                    await CreateChatOnInit(textRequest, cancellationToken);
                }
                if (!await _userReadRepository.Contains(textRequest.UserSourceId, cancellationToken))
                {
                    await CreateUserOnInit(textRequest, cancellationToken);
                }
                await _chatService.CreateMessage(textRequest, cancellationToken);
            }
        }

        private async Task ProcessFromAudio(IMessageRequest request, CancellationToken cancellationToken)
        {
            if (request is CreateAudioMessageRequest audioRequest)
            {
                var textRequest = await _audioService.GetTextMessage(audioRequest, cancellationToken);
                if (!await _chatReadRepository.Contains(audioRequest.ChatSourceId, cancellationToken))
                {
                    await CreateChatOnInit(textRequest, cancellationToken);
                }
                await _chatService.CreateMessage(textRequest, cancellationToken);
            }
        }
        
        private async Task CreateChatOnInit(CreateMessageRequest request, CancellationToken cancellationToken)
        {
            var createChat = new CreateChatRequest
            {
                SourceId = request.ChatSourceId,
                Source = request.Source
            };
            await _chatService.CreateChat(createChat, cancellationToken);
        }
        
        private async Task CreateUserOnInit(CreateMessageRequest request, CancellationToken cancellationToken)
        {
            // TODO: get name and birthday from source
            var createUser = new CreateUserRequest
            {
                SourceId = request.UserSourceId,
                Source = ChatConsts.TELEGRAM_SOURCE,
                Birthday = DateTime.Now,
                Name = request.UserSourceId
            };
            await _chatService.CreateUser(createUser, cancellationToken);
        }
    }
}