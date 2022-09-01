using Microsoft.Extensions.Caching.Memory;
using System;

namespace CityBee_task.Models
{
    public static class CacheModel
    {
        private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public static void Add(string cacheKey, Object value)
        {
            var cacheExpireOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };
            _memoryCache.Set(cacheKey, value, cacheExpireOptions);
        }
        public static Object Get(string cacheKey)
        {
            var result = _memoryCache.Get(cacheKey);
            return result;
        }

        public static void Delete(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
