using BinanceReactDemo.API.DataTransferObject;

namespace BinanceReactDemo.API.Repostories.BuyCoin.Interfaces
{
    /// <summary>
    /// Interface Buy Coin For Customer
    /// </summary>
    public interface IBuyCoinRepository
    {
        /// <summary>
        /// Buy Coin
        /// </summary>
        /// <param name="buyCoin">Buy Coin Dto</param>
        /// <returns>True Or False</returns>
        public Task<bool> BuyCoins(BuyCoinDto buyCoin);
    }
}
