using BinanceReactDemo.API.DataTransferObject;

namespace BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface
{
    public interface ICustomerCoinTables
    {
        public Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsById(int customerId);
        public Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsById(int customerId);
        public Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId);
    }
}
