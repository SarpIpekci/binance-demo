using BinanceReactDemo.Business.Abstract.SignIn;
using BinanceReactDemo.Common.PasswordHashHelper;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete.SignIn
{
    /// <summary>
    /// Sign In Service
    /// </summary>
    public class SignInService : ISignInService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Sign In Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work Factory</param>
        public SignInService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Check Customer Exists
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns>True Or False</returns>
        public async Task<bool> CheckCustomerExits(SignInDto signInDto)
        {
            signInDto.Password = PasswordHash.HashPassword(signInDto.Password);

            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var signInChecUser = await unitOfWork.SignInRepository.CheckCustomerExistsAsync(signInDto);

            unitOfWork.CloseConnection();

            return signInChecUser;
        }

        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public async Task<SignInRequestDto> CustomerLogin(SignInDto signInDto)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var signIn = await unitOfWork.SignInRepository.CheckCustomerAsync(signInDto);

            unitOfWork.CloseConnection();

            return signIn;
        }
    }
}
