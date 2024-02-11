using BinanceReactDemo.Business.Abstract.CustomerCoinTable;
using BinanceReactDemo.CacheManager.Abstract;
using BinanceReactDemo.Common.Caching;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;
using System.Collections.Generic;

namespace BinanceReactDemo.Business.Concrete.CustomerCoinTable
{
    public class CustomerCoinTableService : ICustomerCoinTableService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICacheManager _cacheManager;

        public CustomerCoinTableService(IUnitOfWorkFactory unitOfWorkFactory, ICacheManager cacheManager)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId)
        {
            var allCoinsFromCache = await _cacheManager.GetAsync<IEnumerable<CustomerCoinAllTableDto>>(CacheConstants.GetAllCoinsById);

            if (allCoinsFromCache != null)
            {
                return allCoinsFromCache;
            }

            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var allCoin = await unitOfWork.CustomerCoinTableRepository.GetAllCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

            await _cacheManager.AddAsync(CacheConstants.GetAllCoinsById, allCoin);

            return allCoin;
        }

        /// <summary>
        /// Get Buy Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinBuyTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsById(int customerId)
        {
            var buyCoinsFromCache = await _cacheManager.GetAsync<IEnumerable<CustomerCoinBuyTableDto>>(CacheConstants.GetBuyCoinsById);

            if (buyCoinsFromCache != null)
            {
                return buyCoinsFromCache;
            }

            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var buyCoin = await unitOfWork.CustomerCoinTableRepository.GetBuyCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

            await _cacheManager.AddAsync(CacheConstants.GetBuyCoinsById, buyCoin);

            return buyCoin;
        }

        /// <summary>
        /// Get Sell Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinSellTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsById(int customerId)
        {
            var sellCoinsFromCache = await _cacheManager.GetAsync<IEnumerable<CustomerCoinSellTableDto>>(CacheConstants.GetSellCoinsById);

            if (sellCoinsFromCache != null)
            {
                return sellCoinsFromCache;
            }

            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var sellCoin = await unitOfWork.CustomerCoinTableRepository.GetSellCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

            await _cacheManager.AddAsync(CacheConstants.GetSellCoinsById, sellCoin);

            return sellCoin;
        }
    }
}
