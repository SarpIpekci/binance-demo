using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using BinanceReactDemo.Common.SqlQueries;
using BinanceReactDemo.Common.UserInformationSqlErrorMessages;
using BinanceReactDemo.DataTransferObject.Models;
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
                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signInDto.Username, DbType.String);
                checkUsernameParameters.Add("@password", signInDto.Password, DbType.String);

                using var connection = _context.CreateConnection();
                var existingUser = await connection.ExecuteScalarAsync<int>(SqlQueries.CheckUsernameQuery, checkUsernameParameters);

                var result = connection.QueryFirstOrDefault<SignInRequestDto>(SqlQueries.CustomerIdQuery, checkUsernameParameters);

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
                throw new ArgumentException(UserInformationSqlErrorMessages.SqlError, exception);
            }
        }
    }
}
