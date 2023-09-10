using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface;
using Dapper;
using System.Data;

namespace BinanceReactDemo.API.Repostories.CustomerCoinTable.Abstract
{
    public class CustomerCoinTables : ICustomerCoinTables
    {
        private readonly DapperContext _context;

        /// <summary>
        /// Ctor Buy Coin For Customer
        /// </summary>
        /// <param name="context">Db Context</param>
        public CustomerCoinTables(DapperContext context) => _context = context;

        public async Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId)
        {
            try
            {
                const string query = "select cus.CustomerName,buy.CoinName as BuyCoinName,sell.CoinName as SellCoinName,CAST(buy.CoinValue AS float) as BuyCoinValue,CAST(sell.CoinValue as float) as SellCoinValue,Cast(buy.CustomerBuyValue as float) as BuyCustomerValue,Cast(sell.CustomerSellValue as float) as SellCustomerValue,Cast(buy.SumOfValue as float) as BuySumOfValue,Cast(sell.SumOfValue as float) as SellSumOfValue,(Cast(buy.SumOfValue as float) - Cast(sell.SumOfValue as float)) as [Differences],buy.BuyDate,sell.SellDate from BuyCoin as buy WITH (NOLOCK) Inner Join SellCoin as sell on buy.CustomerId = sell.CustomerId Inner Join Customer as cus on buy.CustomerId = cus.Id Where buy.CustomerId = @customerId";

                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinAllTableDto>(query, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }

        public async Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsById(int customerId)
        {
            try
            {
                const string query = "SELECT buy.Id as OperationId,cus.CustomerName,buy.CoinName,Cast(buy.CoinValue as float) as CoinValue,Cast(buy.CustomerBuyValue as float) as CustomerBuyValue,Cast(buy.SumOfValue as float) as SumOfValue,buy.BuyDate from BuyCoin as buy WITH (NOLOCK) Inner Join Customer as cus on buy.CustomerId = cus.Id Where buy.CustomerId = @customerId";

                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinBuyTableDto>(query, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }

        public async Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsById(int customerId)
        {
            try
            {
                const string query = "SELECT sell.Id as OperationId,cus.CustomerName,sell.CoinName,Cast(sell.CoinValue as float) as CoinValue,Cast(sell.CustomerSellValue as float) as CustomerSellValue,Cast(sell.SumOfValue as float) as SumOfValue,sell.SellDate from SellCoin as sell WITH (NOLOCK) Inner Join Customer as cus on sell.CustomerId = cus.Id Where sell.CustomerId = @customerId";

                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinSellTableDto>(query, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }
    }
}
