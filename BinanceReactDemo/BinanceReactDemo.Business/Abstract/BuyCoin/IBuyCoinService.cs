using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.Business.Abstract
{
    /// <summary>
    /// Interface Buy Coin For Customer
    /// </summary>
    public interface IBuyCoinService
    {
        /// <summary>
        /// Buy Coin
        /// </summary>
        /// <param name="buyCoin">Buy Coin Dto</param>
        /// <returns>True Or False</returns>
        public Task<bool> BuyCoins(BuyCoinDto buyCoin);
    }
}
