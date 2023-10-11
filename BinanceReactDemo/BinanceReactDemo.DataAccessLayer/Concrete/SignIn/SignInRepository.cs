using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataAccessLayer.Abstract.SignIn;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.DataAccessLayer.Concrete.SignIn
{
    /// <summary>
    /// Sign In Repository
    /// </summary>
    public class SignInRepository : RepositoryBase, ISignInRepository
    {
        /// <summary>
        /// Sign In Repository
        /// </summary>
        /// <param name="dbConnection">Database Connection</param>
        /// <param name="dbTransaction">Database Transaction</param>
        public SignInRepository(IDbConnection dbConnection, IDbTransaction? dbTransaction) : base(dbConnection, dbTransaction)
        {
        }

        /// <summary>
        /// Check Customer Exists
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns>True Or False</returns>
        public async Task<bool> CheckCustomerExistsAsync(SignInDto signInDto)
        {
            try
            {
                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signInDto.Username, DbType.String);
                checkUsernameParameters.Add("@password", signInDto.Password, DbType.String);

                var existingUser = await DbConnection.ExecuteScalarAsync<int>(SqlQueries.CheckUsernameQuery, checkUsernameParameters);

                return existingUser > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }

        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<SignInRequestDto> CheckCustomerAsync(SignInDto signInDto)
        {
            try
            {
                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signInDto.Username, DbType.String);
                checkUsernameParameters.Add("@password", signInDto.Password, DbType.String);

                return DbConnection.QueryFirstOrDefault<SignInRequestDto>(SqlQueries.CustomerIdQuery, checkUsernameParameters);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
