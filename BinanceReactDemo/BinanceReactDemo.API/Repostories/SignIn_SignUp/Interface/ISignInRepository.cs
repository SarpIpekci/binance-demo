using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface
{
    /// <summary>
    /// Interface Sign In Repository
    /// </summary>
    public interface ISignInRepository
    {
        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public Task<(bool checkUserExists, SignInRequestDto)> CustomerLogin(SignInDto signInDto);
    }
}
