using System;
using System.Threading.Tasks;
using ClientBarometer.Domain.Services;
using Microsoft.AspNetCore.SignalR;

namespace ClientBarometer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatHubService _chatHubService;

        public ChatHub(IChatHubService chatHubService)
        {
            _chatHubService = chatHubService;
        }
        
        public Task SubscribeToChat(Guid chatId)
        {
            return _chatHubService.SubscribeToChat(chatId, Context.ConnectionId);
        }

        public Task UnsubscribeFromChat(Guid chatId)
        {
            return _chatHubService.UnsubscribeFromChat(chatId, Context.ConnectionId);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return _chatHubService.UnsubscribeFromAllChats(Context.ConnectionId);
        }
    }
}