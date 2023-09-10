using BinanceReactDemo.API.Context;
using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using Dapper;
using System.Data;

namespace BinanceReactDemo.API.Repostories.SignIn_SignUp.Abstract
{
    /// <summary>
    /// Sign Up Repository
    /// </summary>
    public class SignUpRepository : ISignUpRepository
    {
        private readonly DapperContext _context;

        public SignUpRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Create New Customer
        /// </summary>
        /// <param name="signUp">Sign Up Dto</param>
        /// <returns>True Or False</returns>
        /// <exception cref="ArgumentException">Exception</exception>
        public async Task<bool> CreateCustomer(SignUpDto signUp)
        {
            try
            {
                const string checkUsernameQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @username";
                const string query = "INSERT INTO Customer(CustomerName,CustomerEmail,Username,Password,PasswordRepeat) VALUES(@customerName,@customerEmail,@username,@password,@passwordRepeat)";

                var checkUsernameParameters = new DynamicParameters();
                checkUsernameParameters.Add("@username", signUp.Username, DbType.String);

                using var connection = _context.CreateConnection();
                var existingUserCount = await connection.ExecuteScalarAsync<int>(checkUsernameQuery, checkUsernameParameters);

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

                var rowAffected = await connection.ExecuteAsync(query, parameters);

                return rowAffected > 0;
            }
            catch (Exception exception)
            {
                throw new ArgumentException("An error occurred while executing SQL queries.", exception);
            }
        }
    }
}
