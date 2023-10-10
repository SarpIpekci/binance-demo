using BinanceReactDemo.Business.Abstract.SignIn;
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
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        public async Task<(bool checkUserExists, SignInRequestDto)> CustomerLogin(SignInDto signInDto)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var signIn = await unitOfWork.SignInRepository.CustomerLoginAsync(signInDto);

            unitOfWork.CloseConnection();

            return signIn;
        }
    }
}
