namespace BinanceReactDemo.CacheManager.Abstract
{
    /// <summary>
    /// Redis cache manager class
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Add data in Redis Cacher
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <param name="value">Cache Value</param>
        /// <returns></returns>
        Task AddAsync(string key, object value);

        /// <summary>
        /// Dynamic Get Data From Redis
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Cache Key</param>
        /// <returns></returns>
        Task<T?> GetAsync<T>(string key) where T : class;

        /// <summary>
        /// Remove Cache data in Redis
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <returns></returns>
        Task RemoveAsync(string key);
    }
}
