using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Models.SellCoin;
using BinanceReactDemo.API.Repostories.SellCoin.Interfaces;
using Dapper;
using System.Data;

namespace BinanceReactDemo.API.Repostories.SellCoin.Abstract
{
    public class SellCoinRepository : ISellCoinRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// Ctor Buy Coin For Customer
        /// </summary>
        /// <param name="context">Db Context</param>
        public SellCoinRepository(DapperContext context) => _context = context;

        public async Task<bool> SellCoins(SellCoinModel sellCoin)
        {
            try
            {
                const string query = "INSERT INTO SellCoin(CustomerId,CoinName,CoinValue,CustomerSellValue,SumOfValue,SellDate) VALUES(@customerId,@coinName,@coinValue,@customerSellValue,@sumOfValue,@sellDate)";

                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", sellCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", sellCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", sellCoin.CoinValue, DbType.Double);
                parameters.Add("@customerSellValue", sellCoin.CustomerSellValue, DbType.Double);
                parameters.Add("@sumOfValue", sellCoin.SumOfValue, DbType.String);
                parameters.Add("@sellDate", sellCoin.SellDate, DbType.DateTime);

                var rowAffected = await connection.ExecuteAsync(query, parameters);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }
    }
}
