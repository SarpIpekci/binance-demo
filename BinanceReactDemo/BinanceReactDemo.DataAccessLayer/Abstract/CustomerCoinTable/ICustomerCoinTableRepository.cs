using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.CustomerCoinTable
{
    /// <summary>
    /// Customer Coin Table Repository
    /// </summary>
    public interface ICustomerCoinTableRepository
    {
        /// <summary>
        /// Get Buy Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinBuyTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsAsyncById(int customerId);

        /// <summary>
        /// Get Sell Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinSellTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsAsyncById(int customerId);

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsAsyncById(int customerId);
    }
}
