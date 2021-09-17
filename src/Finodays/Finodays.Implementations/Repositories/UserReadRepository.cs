using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finodays.DataAccess;
using Finodays.Domain.Constants;
using Finodays.Domain.Models;
using Finodays.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Finodays.Implementations.Repositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly IQueryable<User> _users;

        public UserReadRepository(FinodaysDbContext dbContext)
        {
            _users = dbContext.Users.AsNoTracking();
        }
        
        public async Task<User> Get(Guid userId, CancellationToken cancellationToken)
            => await _users
            .FirstOrDefaultAsync(us => us.Id == userId, cancellationToken);
        
        public async Task<User> Get(int userIntId, CancellationToken cancellationToken)
            => await _users
                .FirstOrDefaultAsync(us => us.IntId == userIntId, cancellationToken);

        public async Task<bool> Contains(Guid userId, CancellationToken cancellationToken)
            => await _users
                .AnyAsync(us => us.Id == userId, cancellationToken);

        public async Task<User[]> GetUsers(int skip, int take, CancellationToken cancellationToken)
            => await _users
            .Skip(skip)
            .Take(take)
            .ToArrayAsync(cancellationToken);
    }
}
