using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBarometer.Implementations.Services
{
    public class SuggestionServiceCache
    {
        private static SuggestionServiceCache _instance;
        private readonly Dictionary<Guid, List<Guid>> _cache = new ();

        private SuggestionServiceCache()
        {
        }

        public void AddToCache(Guid clientId, Guid suggestionId)
        {
            if(_cache.ContainsKey(clientId))
            {
                _cache[clientId].Add(suggestionId);
            }
            else
            {
                _cache.Add(clientId, new List<Guid> { suggestionId });
            }
        }

        public Guid[] GetFromCache(Guid clientId)
        {
            var success = _cache.TryGetValue(clientId, out var suggestionsId);
            return success ? suggestionsId.ToArray() : Array.Empty<Guid>();
        }

        public void ClearCache()
        {
            _cache.Clear();
        }

        public static SuggestionServiceCache GetInstance()
        {
            return _instance ??= new SuggestionServiceCache();
        }
    }
}
