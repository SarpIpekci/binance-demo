using BinanceReactDemo.Validation.BuyCoin;
using BinanceReactDemo.Validation.SellCoin;
using BinanceReactDemo.Validation.SignIn;
using BinanceReactDemo.Validation.SignUp;
using Microsoft.Extensions.DependencyInjection;

namespace BinanceReactDemo.Validation
{
    /// <summary>
    /// Servis Scopes
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Add Validation Service Scopes
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddScoped<SignUpValidation>();
            services.AddScoped<SignInValidation>();
            services.AddScoped<BuyCoinValidation>();
            services.AddScoped<SellCoinValidation>();
        }
    }
}
