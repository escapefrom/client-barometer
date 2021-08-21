using ClientBarometer.DataAccess;
using ClientBarometer.Domain.Models;
using ClientBarometer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBarometer.Implementations.Repositories
{
    public class ObjectionHandlingReadRepository : IObjectionHandlingReadRepository
    {
        private readonly IQueryable<Objection> _objections;

        public ObjectionHandlingReadRepository(ClientBarometerDbContext dbContext)
        {
            _objections = dbContext.Objections.AsNoTracking();
        }

        public async Task<Objection[]> GetAllObjections(int skip, int take, CancellationToken cancellationToken)
            => await _objections
                .Skip(skip)
                .Take(take)
                .ToArrayAsync(cancellationToken);
    }
}
