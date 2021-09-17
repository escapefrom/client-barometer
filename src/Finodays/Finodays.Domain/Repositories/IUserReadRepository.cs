using System;
using System.Threading;
using System.Threading.Tasks;
using Finodays.Domain.Models;

namespace Finodays.Domain.Repositories
{
    public interface IUserReadRepository
    {
        Task<User> Get(Guid userId, CancellationToken cancellationToken);
        Task<User> Get(int userIntId, CancellationToken cancellationToken);
        Task<bool> Contains(Guid userId, CancellationToken cancellationToken);
        Task<User[]> GetUsers(int skip, int take, CancellationToken cancellationToken);
    }
}