using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.SignIn
{
    /// <summary>
    /// Sign In Repository Interface
    /// </summary>
    public interface ISignInRepository
    {
        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public Task<(bool checkUserExists, SignInRequestDto)> CustomerLoginAsync(SignInDto signInDto);
    }
}
