using BinanceReactDemo.Business.Abstract.SellCoin;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete.SellCoin
{
    /// <summary>
    /// Sell Coin Service
    /// </summary>
    public class SellCoinService : ISellCoinService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Sell Coin Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work</param>
        public SellCoinService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Sell Coins
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> SellCoins(SellCoinDto sellCoin)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            unitOfWork.BeginTransaction();

            var sellCoins = await unitOfWork.SellCoinRepository.SellCoinAsync(sellCoin);

            unitOfWork.CommitTransaction();

            unitOfWork.CloseConnection();

            return sellCoins;
        }
    }
}
