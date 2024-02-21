using BinanceReactDemo.Business.Abstract.SellCoin;
using BinanceReactDemo.CacheManager.Abstract;
using BinanceReactDemo.Common.Caching;
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
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// Sell Coin Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work</param>
        public SellCoinService(IUnitOfWorkFactory unitOfWorkFactory, ICacheManager cacheManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Sell Coins
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> SellCoins(SellCoinDto sellCoin)
        {
            await _cacheManager.RemoveAsync($"{CacheConstants.GetSellCoinsById}:{sellCoin.CustomerId}");

            await _cacheManager.RemoveAsync($"{CacheConstants.GetAllCoinsById}:{sellCoin.CustomerId}");

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
