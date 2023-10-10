using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Abstract.SignIn
{
    /// <summary>
    /// Sign In Service Interface
    /// </summary>
    public interface ISignInService
    {
        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public Task<(bool checkUserExists, SignInRequestDto)> CustomerLogin(SignInDto signInDto);
    }
}
