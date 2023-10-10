using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataAccessLayer.Abstract.CustomerCoinTable;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.DataAccessLayer.Concrete.CustomerCoinTable
{
    public class CustomerCoinTableRepository : RepositoryBase, ICustomerCoinTableRepository
    {
        public CustomerCoinTableRepository(IDbConnection dbConnection, IDbTransaction? dbTransaction) : base(dbConnection, dbTransaction)
        {
        }

        /// <summary>
        /// Get Buy Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinBuyTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsAsyncById(int customerId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await DbConnection.QueryAsync<CustomerCoinAllTableDto>(SqlQueries.GetAllCoinsByIdQuery, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }

        /// <summary>
        /// Get Sell Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinSellTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsAsyncById(int customerId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await DbConnection.QueryAsync<CustomerCoinBuyTableDto>(SqlQueries.GetBuyCoinsByIdQuery, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsAsyncById(int customerId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await DbConnection.QueryAsync<CustomerCoinSellTableDto>(SqlQueries.GetSellCoinsByIdQuery, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
