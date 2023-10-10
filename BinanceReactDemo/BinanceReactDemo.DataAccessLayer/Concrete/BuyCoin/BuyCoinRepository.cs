using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataAccessLayer.Abstract.BuyCoin;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.DataAccessLayer.Concrete.BuyCoin
{
    public class BuyCoinRepository : RepositoryBase, IBuyCoinRepository
    {
        public BuyCoinRepository(IDbConnection dbConnection, IDbTransaction? dbTransaction) : base(dbConnection, dbTransaction)
        {

        }

        public async Task<bool> BuyCoinAsync(BuyCoinDto buyCoin)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", buyCoin.CustomerId, DbType.Int32);
                parameters.Add("@coinName", buyCoin.CoinName, DbType.String);
                parameters.Add("@coinValue", buyCoin.CoinValue, DbType.Double);
                parameters.Add("@customerBuyValue", buyCoin.CustomerBuyValue, DbType.Double);
                parameters.Add("@sumOfValue", buyCoin.SumOfValue, DbType.String);
                parameters.Add("@buyDate", buyCoin.BuyDate, DbType.DateTime);

                var rowAffected = await DbConnection.ExecuteAsync(SqlQueries.BuyCoinsQuery, parameters, transaction: DbTransaction);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
