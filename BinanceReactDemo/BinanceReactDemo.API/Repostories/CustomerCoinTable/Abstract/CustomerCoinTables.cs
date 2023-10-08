using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface;
using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataTransferObject.Models;
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

        /// <summary>
        /// Get All Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinAllTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinAllTableDto>> GetAllCoinsById(int customerId)
        {
            try
            {
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinAllTableDto>(SqlQueries.GetAllCoinsByIdQuery, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }

        /// <summary>
        /// Get Buy Coins By Id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>IEnumerable<CustomerCoinBuyTableDto></returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<IEnumerable<CustomerCoinBuyTableDto>> GetBuyCoinsById(int customerId)
        {
            try
            {
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinBuyTableDto>(SqlQueries.GetBuyCoinsByIdQuery, parameters);
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
        public async Task<IEnumerable<CustomerCoinSellTableDto>> GetSellCoinsById(int customerId)
        {
            try
            {
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId, DbType.Int32);

                return await connection.QueryAsync<CustomerCoinSellTableDto>(SqlQueries.GetSellCoinsByIdQuery, parameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
