using System;
using System.Linq;
using ClientBarometer.Common.Implementations.Repositories;
using ClientBarometer.Domain.Models;
using ClientBarometer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientBarometer.Implementations.Repositories
{
    class MessageRegisterRepository : RegisterRepository<Message>, IMessageRegisterRepository
    {
        public MessageRegisterRepository(DbSet<Message> dbSet) : base(dbSet)
        {
        }

        public void RegisterDelete(Guid chatId)
        {
            var messages = DbSet.Where(x => x.ChatId == chatId);
            DbSet.RemoveRange(messages);
        }
    }
}