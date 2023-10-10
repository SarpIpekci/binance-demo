using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Abstract.SignUp
{
    /// <summary>
    /// Sign Up Service
    /// </summary>
    public interface ISignUpService
    {
        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        public Task<bool> CreateCustomer(SignUpDto signUp);
    }
}
