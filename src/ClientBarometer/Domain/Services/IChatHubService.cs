using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientBarometer.Domain.Services
{
    public interface IChatHubService
    {
        Task SubscribeToChat(Guid chatId, string connectionId);
        Task UnsubscribeFromChat(Guid chatId, string connectionId);
        Task UnsubscribeFromAllChats(string connectionId);

        Task<IEnumerable<string>> GetChatSubscribers(Guid chatId);
    }
}