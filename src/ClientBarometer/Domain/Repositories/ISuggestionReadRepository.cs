using ClientBarometer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBarometer.Domain.Repositories
{
    public interface ISuggestionReadRepository
    {
        public Task<Suggestion[]> GetNextSuggestions(string objectionClass, Guid[] excludeTextId, int skip, int take, CancellationToken cancellationToken);
        public Task<int> GetCount(CancellationToken cancellationToken);
    }
}
