using BinanceReactDemo.Business.Abstract;
using BinanceReactDemo.CacheManager.Abstract;
using BinanceReactDemo.Common.Caching;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete
{
    public class BuyCoinService : IBuyCoinService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// Buy Coin Service
        /// </summary>
        /// <param name="unitOfWorkFactory">Unit Of Work Factory</param>
        public BuyCoinService(IUnitOfWorkFactory unitOfWorkFactory, ICacheManager cacheManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Buy Coin
        /// </summary>
        /// <param name="buyCoin">Buy Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> BuyCoins(BuyCoinDto buyCoin)
        {
            await _cacheManager.RemoveAsync(CacheConstants.GetBuyCoinsById);

            await _cacheManager.RemoveAsync(CacheConstants.GetAllCoinsById);

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
