using BinanceReactDemo.DataTransferObject.Models;

namespace BinanceReactDemo.DataAccessLayer.Abstract.BuyCoin
{
    public interface IBuyCoinRepository
    {
        public Task<bool> BuyCoinAsync(BuyCoinDto buyCoin);
    }
}
