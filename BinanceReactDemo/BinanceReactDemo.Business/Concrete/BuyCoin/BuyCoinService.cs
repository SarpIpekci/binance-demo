using BinanceReactDemo.Business.Abstract;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete
{
    public class BuyCoinService : IBuyCoinService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Buy Coin Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work Factory</param>
        public BuyCoinService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Buy Coin
        /// </summary>
        /// <param name="buyCoin">Buy Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> BuyCoins(BuyCoinDto buyCoin)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            unitOfWork.BeginTransaction();

            var buyCoins = await unitOfWork.BuyCoinRepository.BuyCoinAsync(buyCoin);

            unitOfWork.CommitTransaction();

            unitOfWork.CloseConnection();

            return buyCoins;
        }
    }
}
