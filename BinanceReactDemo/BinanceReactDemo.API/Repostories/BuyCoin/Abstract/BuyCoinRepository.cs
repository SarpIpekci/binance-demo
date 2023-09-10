using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Repostories.BuyCoin.Interfaces;
using Dapper;
using System.Data;
using BinanceReactDemo.API.Models.BuyCoin;

namespace BinanceReactDemo.API.Repostories.BuyCoin.Abstract
{
    /// <summary>
    /// Buy Coin For Customer
    /// </summary>
    public class BuyCoinRepository : IBuyCoinRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// Ctor Buy Coin For Customer
        /// </summary>
        /// <param name="context">Db Context</param>
        public BuyCoinRepository(DapperContext context) => _context = context;

        public async Task<bool> BuyCoins(BuyCoinModel buyCoin)
        {
            try
            {
                const string query = "INSERT INTO BuyCoin(CustomerId,CoinName,CoinValue,CustomerBuyValue,SumOfValue,BuyDate) VALUES(@customerId,@coinName,@coinValue,@customerBuyValue,@sumOfValue,@buyDate)";

                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", buyCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", buyCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", buyCoin.CoinValue, DbType.Double);
                parameters.Add("@customerBuyValue", buyCoin.CustomerBuyValue, DbType.Double);
                parameters.Add("@sumOfValue", buyCoin.SumOfValue, DbType.String);
                parameters.Add("@buyDate", buyCoin.BuyDate, DbType.DateTime);

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
