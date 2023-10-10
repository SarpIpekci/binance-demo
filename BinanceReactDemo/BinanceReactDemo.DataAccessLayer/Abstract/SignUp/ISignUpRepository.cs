using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.SignUp
{
    /// <summary>
    /// Sign Up Repository Service
    /// </summary>
    public interface ISignUpRepository
    {
        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        public Task<bool> CreateCustomerAsync(SignUpDto signUp);
    }
}
