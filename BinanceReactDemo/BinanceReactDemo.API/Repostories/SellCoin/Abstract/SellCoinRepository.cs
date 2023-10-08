using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Repostories.SellCoin.Interfaces;
using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.API.Repostories.SellCoin.Abstract
{
    /// <summary>
    /// Sell Coin Repository
    /// </summary>
    public class SellCoinRepository : ISellCoinRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// Ctor Buy Coin For Customer
        /// </summary>
        /// <param name="context">Db Context</param>
        public SellCoinRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Sell Coins
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> SellCoins(SellCoinDto sellCoin)
        {
            try
            {
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", sellCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", sellCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", sellCoin.CoinValue, DbType.Double);
                parameters.Add("@customerSellValue", sellCoin.CustomerSellValue, DbType.Double);
                parameters.Add("@sumOfValue", sellCoin.SumOfValue, DbType.String);
                parameters.Add("@sellDate", sellCoin.SellDate, DbType.DateTime);

                var rowAffected = await connection.ExecuteAsync(SqlQueries.SellCoinsQuery, parameters);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
