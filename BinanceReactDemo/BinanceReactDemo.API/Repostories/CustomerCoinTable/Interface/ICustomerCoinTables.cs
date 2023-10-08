using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface
{
    /// <summary>
    /// Customer Coin Table
    /// </summary>
    public interface ICustomerCoinTables
    {
        /// <summary>
        /// Get Buy Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinBuyTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsById(int customerId);

        /// <summary>
        /// Get Sell Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinSellTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsById(int customerId);

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId);
    }
}
