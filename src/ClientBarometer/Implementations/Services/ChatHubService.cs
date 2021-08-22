using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientBarometer.Domain.Services;

namespace ClientBarometer.Implementations.Services
{
    public class ChatHubService : IChatHubService
    {
        /// <summary>
        ///     Ключ - идентфиикатор чата (ChatId), значение - список SignalR клиентов
        /// </summary>
        private Dictionary<Guid, HashSet<string>> _clients = new();

        public Task SubscribeToChat(Guid chatId, string connectionId)
        {
            if (_clients.ContainsKey(chatId))
            {
                _clients[chatId].Add(connectionId);
            }
            else
            {
                _clients.Add(chatId, new HashSet<string> {connectionId});
            }

            return Task.CompletedTask;
        }

        public Task UnsubscribeFromChat(Guid chatId, string connectionId)
        {
            if (_clients.ContainsKey(chatId) && _clients[chatId].Contains(connectionId))
            {
                _clients[chatId].Remove(connectionId);
            }

            return Task.CompletedTask;
        }

        public Task UnsubscribeFromAllChats(string connectionId)
        {
            foreach (var (chatId, clients) in _clients)
            {
                if (clients.Contains(connectionId))
                {
                    _clients[chatId].Remove(connectionId);
                }
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<string>> GetChatSubscribers(Guid chatId)
        {
            return _clients.ContainsKey(chatId) ? _clients[chatId] : Enumerable.Empty<string>();
        }
    }
}