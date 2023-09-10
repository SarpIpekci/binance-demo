using BinanceReactDemo.API.Models.SellCoin;

namespace BinanceReactDemo.API.Repostories.SellCoin.Interfaces
{
    public interface ISellCoinRepository
    {
        public Task<bool> SellCoins(SellCoinModel sellCoin);
    }
}
