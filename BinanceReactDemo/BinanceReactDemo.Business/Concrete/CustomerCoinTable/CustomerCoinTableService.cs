using BinanceReactDemo.Business.Abstract.CustomerCoinTable;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Concrete.CustomerCoinTable
{
    public class CustomerCoinTableService : ICustomerCoinTableService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CustomerCoinTableService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var allCoin = await unitOfWork.CustomerCoinTableRepository.GetAllCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

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
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var buyCoin = await unitOfWork.CustomerCoinTableRepository.GetBuyCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

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
            using var unitOfWork = _unitOfWorkFactory.Create();

            unitOfWork.OpenConnection();

            var sellCoin = await unitOfWork.CustomerCoinTableRepository.GetSellCoinsAsyncById(customerId);

            unitOfWork.CloseConnection();

            return sellCoin;
        }
    }
}
