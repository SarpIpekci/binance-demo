using Microsoft.Extensions.Configuration;

namespace BinanceReactDemo.Core.Extensions
{
    /// <summary>
    /// Configuration Settings
    /// </summary>
    public static class ConfigurationExtension
    {
        private static IConfiguration _configuration = null!;

        /// <summary>
        /// Configuration Settings
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get Configuration
        /// </summary>
        /// <returns></returns>
        public static IConfiguration GetConfiguration()
        {
            return _configuration;
        }

        /// <summary>
        /// Get Configuration Settings Value
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return GetConfiguration().GetSection("ConnectionStrings:SqlConnection").Value;
        }
    }
}
