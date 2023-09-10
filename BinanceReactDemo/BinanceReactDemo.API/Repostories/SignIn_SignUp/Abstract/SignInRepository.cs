using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using Dapper;
using System.Data;

namespace BinanceReactDemo.API.Repostories.SignIn_SignUp.Abstract
{
    /// <summary>
    /// Sign In Repository
    /// </summary>
    public class SignInRepository : ISignInRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// Ctor Sign In Repository
        /// </summary>
        /// <param name="context">Db Context</param>
        public SignInRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Customer Login
        /// </summary>
        /// <param name="signInDto">Sign In Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<(bool checkUserExists, int id)> CustomerLogin(SignInDto signInDto)
        {
            try
            {
                const string checkUsernameQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @username AND Password = @password";

                const string customerIdQuery = "SELECT Id as id FROM Customer WHERE Username = @username AND Password = @password";

                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signInDto.Username, DbType.String);
                checkUsernameParameters.Add("@password", signInDto.Password, DbType.String);

                using var connection = _context.CreateConnection();
                var existingUser = await connection.ExecuteScalarAsync<int>(checkUsernameQuery, checkUsernameParameters);

                var customerId = connection.Query<int>(customerIdQuery, checkUsernameParameters).FirstOrDefault();

                if (existingUser > 0)
                {
                    return (true, customerId);
                }
                else
                {
                    return (false, customerId);
                }
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }
    }
}
