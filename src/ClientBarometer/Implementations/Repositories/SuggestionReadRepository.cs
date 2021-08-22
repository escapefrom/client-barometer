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
    public class SuggestionReadRepository : ISuggestionReadRepository
    {
        private readonly IQueryable<Suggestion> _suggestions;

        public SuggestionReadRepository(ClientBarometerDbContext dbContext)
        {
            _suggestions = dbContext.Suggestions.AsNoTracking();
        }

        public async Task<Suggestion[]> GetNextSuggestions(string objectionClass, Guid[] excludeTextIds, int skip, int take, CancellationToken cancellationToken)
            => await _suggestions
                .Where((sug) => objectionClass.ToLower() == sug.ObjectionClass.ToLower() && !excludeTextIds.Contains(sug.Id))
                .Skip(skip)
                .Take(take)
                .ToArrayAsync(cancellationToken);

        public async Task<int> GetCount(CancellationToken cancellationToken)
            => await _suggestions.CountAsync(cancellationToken);
    }
}
