using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace VerifyMeIntegration
{
    public class CacheService : ICacheService
    {
        private IMemoryCache MemoryCache { get; set; }
        public CacheService(IMemoryCache memoryCache)
        {
            this.MemoryCache = memoryCache;
        }

        public void Set<T>(string key, T value, int hours = 24)
        {
            if (this.MemoryCache.Get(key) == null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(hours));
                this.MemoryCache.Set<T>(key, value, cacheEntryOptions);
            }
        }

        public T Get<T>(string key)
        {
            var result = this.MemoryCache.Get<T>(key);
            return result;
        }

        public void Clear(string key)
        {
            this.MemoryCache.Remove(key);
        }
    }
}
