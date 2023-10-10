using BinanceReactDemo.DataAccessLayer.Abstract.BuyCoin;
using BinanceReactDemo.DataAccessLayer.Abstract.CustomerCoinTable;
using BinanceReactDemo.DataAccessLayer.Abstract.SellCoin;
using BinanceReactDemo.DataAccessLayer.Abstract.SignIn;
using BinanceReactDemo.DataAccessLayer.Abstract.SignUp;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using BinanceReactDemo.DataAccessLayer.Concrete.BuyCoin;
using BinanceReactDemo.DataAccessLayer.Concrete.CustomerCoinTable;
using BinanceReactDemo.DataAccessLayer.Concrete.SellCoin;
using BinanceReactDemo.DataAccessLayer.Concrete.SignIn;
using BinanceReactDemo.DataAccessLayer.Concrete.SignUp;
using Microsoft.Extensions.Logging;
using System.Data;

namespace SmartAdmin.DotNetSix.DataAccess.Concrete.UnitOfWork
{
    /// <summary>
    /// Defines the repositories that will enter the transaction.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;

        private readonly IDbConnection _connection;
        private IDbTransaction? _transaction;

        /// <summary>
        /// UnitOfWork Connection
        /// </summary>
        /// <param name="connection">Connection</param>
        /// <param name="logger">Logger</param>
        public UnitOfWork(IDbConnection connection, ILogger<UnitOfWork> logger)
        {
            _connection = connection;
            _logger = logger;
        }

        /// <summary>
        /// Go to Buy Coin Repository
        /// </summary>
        public IBuyCoinRepository BuyCoinRepository => new BuyCoinRepository(_connection, _transaction);

        /// <summary>
        /// Go to Sell Coin Repository
        /// </summary>
        public ISellCoinRepository SellCoinRepository => new SellCoinRepository(_connection, _transaction);

        /// <summary>
        /// Go to Sign In Repository
        /// </summary>
        public ISignInRepository SignInRepository => new SignInRepository(_connection, _transaction);

        /// <summary>
        /// Go to Sign Up Repository
        /// </summary>
        public ISignUpRepository SignUpRepository => new SignUpRepository(_connection, _transaction);

        /// <summary>
        /// Go to Customer Table Repository
        /// </summary>
        public ICustomerCoinTableRepository CustomerCoinTableRepository => new CustomerCoinTableRepository(_connection, _transaction);

        /// <summary>
        /// Open Connection
        /// </summary>
        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection?.Open();
            }
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection?.Close();
            }
        }

        /// <summary>
        /// transaction starts.
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, $"UnitOfWork {nameof(BeginTransaction)} failed");
            }
        }

        /// <summary>
        /// Commit transaction.
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (Exception exception)
            {
                _transaction?.Rollback();

                _logger?.LogError(exception, $"UnitOfWork {nameof(CommitTransaction)} failed");
            }
        }

        /// <summary>
        /// Rolevback transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, $"UnitOfWork {nameof(RollbackTransaction)} failed");
            }
        }

        /// <summary>
        /// Dispose transaction or connection
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
