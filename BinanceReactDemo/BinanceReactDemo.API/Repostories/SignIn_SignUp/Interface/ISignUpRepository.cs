using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface
{
    /// <summary>
    /// Sign Up Repository
    /// </summary>
    public interface ISignUpRepository
    {
        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        public Task<bool> CreateCustomer(SignUpDto signUp);
    }
}
