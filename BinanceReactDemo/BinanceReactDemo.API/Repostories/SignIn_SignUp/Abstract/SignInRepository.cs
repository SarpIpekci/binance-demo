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
        public async Task<(bool checkUserExists, SignInRequestDto)> CustomerLogin(SignInDto signInDto)
        {
            try
            {
                const string checkUsernameQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @username AND Password = @password";

                const string customerIdQuery = "SELECT Id, Username FROM Customer WHERE Username = @username AND Password = @password";

                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signInDto.Username, DbType.String);
                checkUsernameParameters.Add("@password", signInDto.Password, DbType.String);

                using var connection = _context.CreateConnection();
                var existingUser = await connection.ExecuteScalarAsync<int>(checkUsernameQuery, checkUsernameParameters);

                var result = connection.QueryFirstOrDefault<SignInRequestDto>(customerIdQuery, checkUsernameParameters);

                if (existingUser > 0)
                {
                    return (true, result);
                }
                else
                {
                    return (false, result);
                }
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }
    }
}
