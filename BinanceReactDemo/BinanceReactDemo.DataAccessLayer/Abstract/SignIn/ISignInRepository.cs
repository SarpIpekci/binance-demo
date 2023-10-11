using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.SignIn
{
    /// <summary>
    /// Sign In Repository Interface
    /// </summary>
    public interface ISignInRepository
    {
        /// <summary>
        /// Check Customer Exists
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns>True Or False</returns>
        public Task<bool> CheckCustomerExistsAsync(SignInDto signInDto);

        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public Task<SignInRequestDto> CheckCustomerAsync(SignInDto signInDto);
    }
}
