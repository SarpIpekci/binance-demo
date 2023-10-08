using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.API.Repostories.SellCoin.Interfaces
{
    /// <summary>
    /// Sell Coin Repository
    /// </summary>
    public interface ISellCoinRepository
    {
        /// <summary>
        /// Sell Coins
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public Task<bool> SellCoins(SellCoinDto sellCoin);
    }
}
