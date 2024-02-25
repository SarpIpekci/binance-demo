using BinanceReactDemo.Business.Abstract.SignUp;
using BinanceReactDemo.Common.SecurityHelper.PasswordHashHelper;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete.SignUp
{
    /// <summary>
    /// Sign Up Service
    /// </summary>
    public class SignUpService : ISignUpService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Sign Up Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work Factory</param>
        public SignUpService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        public async Task<bool> CreateCustomer(SignUpDto signUp)
        {
            signUp.Password = PasswordHash.HashPassword(signUp.Password);
            signUp.PasswordRepeats = PasswordHash.HashPassword(signUp.PasswordRepeats);

            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var createCustomer = await unitOfWork.SignUpRepository.CreateCustomerAsync(signUp);

            unitOfWork.CloseConnection();

            return createCustomer;
        }
    }
}
