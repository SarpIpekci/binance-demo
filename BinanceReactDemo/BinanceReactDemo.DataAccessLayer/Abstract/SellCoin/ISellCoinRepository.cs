using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.SellCoin
{
    /// <summary>
    /// Sell Coin Repository
    /// </summary>
    public interface ISellCoinRepository
    {
        /// <summary>
        /// Sell Coin Async
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">SQL Excepiton</exception>
        public Task<bool> SellCoinAsync(SellCoinDto sellCoin);
    }
}
