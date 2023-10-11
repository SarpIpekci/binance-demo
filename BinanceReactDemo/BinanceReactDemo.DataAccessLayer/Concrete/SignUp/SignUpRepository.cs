using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataAccessLayer.Abstract.SignUp;
using BinanceReactDemo.DataTransferObject.Models;
using Dapper;
using System.Data;

namespace BinanceReactDemo.DataAccessLayer.Concrete.SignUp
{
    public class SignUpRepository : RepositoryBase, ISignUpRepository
    {
        public SignUpRepository(IDbConnection dbConnection, IDbTransaction? dbTransaction) : base(dbConnection, dbTransaction)
        {
        }

        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> CreateCustomerAsync(SignUpDto signUp)
        {
            try
            {
                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signUp.Username, DbType.String);

                var existingUserCount = await DbConnection.ExecuteScalarAsync<int>(SqlQueries.CheckUsernameSignUpQuery, checkUsernameParameters);

                if (existingUserCount > 0)
                {
                    return false;
                }

                var parameters = new DynamicParameters();
                parameters.Add("@customerName", signUp.CustomerName, DbType.String);
                parameters.Add("@customerEmail", signUp.CustomerEmail, DbType.String);
                parameters.Add("@username", signUp.Username, DbType.String);
                parameters.Add("@password", signUp.Password, DbType.String);
                parameters.Add("@passwordRepeat", signUp.PasswordRepeats, DbType.String);
                parameters.Add("@createdDate", signUp.CreatedDate, DbType.DateTime);

                var rowAffected = await DbConnection.ExecuteAsync(SqlQueries.CreateCustomerQuery, parameters);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
