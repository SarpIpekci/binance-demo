using BinanceReactDemo.CacheManager.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BinanceReactDemo.CacheManager.Concrete
{
    /// <summary>
    /// Redis Control Class
    /// </summary>
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;

        /// <summary>
        /// Redis Control Class
        /// </summary>
        /// <param name="distributedCache">IDistributedCache</param>
        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        /// <summary>
        /// Add data in Redis Cache
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <param name="value">Cache Value</param>
        /// <returns></returns>
        public async Task AddAsync(string key, object value)
        {
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Dynamic Get Data From Redis
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Cache Key</param>
        /// <returns></returns>
        public async Task<T?> GetAsync<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                return default;
            }

            string value = await _distributedCache.GetStringAsync(key);

            if (value == null) return null;

            return JsonSerializer.Deserialize<T>(value);
        }

        /// <summary>
        /// Remove Cache data in Redis
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
