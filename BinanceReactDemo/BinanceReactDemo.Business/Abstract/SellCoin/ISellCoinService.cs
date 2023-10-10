using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Abstract.SellCoin
{
    /// <summary>
    /// Sell Coin Service
    /// </summary>
    public interface ISellCoinService
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
