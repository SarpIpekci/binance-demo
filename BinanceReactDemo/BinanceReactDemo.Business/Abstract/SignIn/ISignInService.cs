using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Abstract.SignIn
{
    /// <summary>
    /// Sign In Service Interface
    /// </summary>
    public interface ISignInService
    {
        /// <summary>
        /// Check Customer Exists
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns>True Or False</returns>
        public Task<bool> CheckCustomerExits(SignInDto signInDto);

        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public Task<SignInRequestDto> CustomerLogin(SignInDto signInDto);
    }
}
