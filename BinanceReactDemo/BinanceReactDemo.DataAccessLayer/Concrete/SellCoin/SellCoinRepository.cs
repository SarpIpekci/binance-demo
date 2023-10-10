using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataAccessLayer.Abstract.SellCoin;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.DataAccessLayer.Concrete.SellCoin
{
    /// <summary>
    /// Sell Coin Repository
    /// </summary>
    public class SellCoinRepository : RepositoryBase, ISellCoinRepository
    {
        /// <summary>
        /// Sell Coin Repository
        /// </summary>
        /// <param name="dbConnection">Database Connection</param>
        /// <param name="dbTransaction">Database Transaction</param>
        public SellCoinRepository(IDbConnection dbConnection, IDbTransaction? dbTransaction) : base(dbConnection, dbTransaction)
        {
        }

        /// <summary>
        /// Sell Coin Async
        /// </summary>
        /// <param name="sellCoin">Sell Coin Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">SQL Excepiton</exception>
        public async Task<bool> SellCoinAsync(SellCoinDto sellCoin)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", sellCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", sellCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", sellCoin.CoinValue, DbType.Double);
                parameters.Add("@customerSellValue", sellCoin.CustomerSellValue, DbType.Double);
                parameters.Add("@sumOfValue", sellCoin.SumOfValue, DbType.String);
                parameters.Add("@sellDate", sellCoin.SellDate, DbType.DateTime);

                var rowAffected = await DbConnection.ExecuteAsync(SqlQueries.SellCoinsQuery, parameters, transaction: DbTransaction);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
