using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Repostories.BuyCoin.Interfaces;
using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

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

        /// <summary>
        /// Buy Coin
        /// </summary>
        /// <param name="buyCoin">Buy Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> BuyCoins(BuyCoinDto buyCoin)
        {
            try
            {
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", buyCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", buyCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", buyCoin.CoinValue, DbType.Double);
                parameters.Add("@customerBuyValue", buyCoin.CustomerBuyValue, DbType.Double);
                parameters.Add("@sumOfValue", buyCoin.SumOfValue, DbType.String);
                parameters.Add("@buyDate", buyCoin.BuyDate, DbType.DateTime);

                var rowAffected = await connection.ExecuteAsync(SqlQueries.BuyCoinsQuery, parameters);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
