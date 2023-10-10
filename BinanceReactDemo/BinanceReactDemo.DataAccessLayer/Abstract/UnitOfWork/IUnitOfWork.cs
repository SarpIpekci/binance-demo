using BinanceReactDemo.DataAccessLayer.Abstract.BuyCoin;
using BinanceReactDemo.DataAccessLayer.Abstract.CustomerCoinTable;
using BinanceReactDemo.DataAccessLayer.Abstract.SellCoin;
using BinanceReactDemo.DataAccessLayer.Abstract.SignIn;
using BinanceReactDemo.DataAccessLayer.Abstract.SignUp;

namespace BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork
{
    /// <summary>
    /// Defines the repositories that will enter the transaction.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Go to Buy Coin Repository
        /// </summary>
        IBuyCoinRepository BuyCoinRepository { get; }

        /// <summary>
        /// Go to Sell Coin Repository
        /// </summary>
        ISellCoinRepository SellCoinRepository { get; }

        /// <summary>
        /// Go to Sign In Repository
        /// </summary>
        ISignInRepository SignInRepository { get; }

        /// <summary>
        /// Go to Sign Up Repository
        /// </summary>
        ISignUpRepository SignUpRepository { get; }

        /// <summary>
        /// Go to Customer Table Repository
        /// </summary>
        ICustomerCoinTableRepository CustomerCoinTableRepository { get; }

        /// <summary>
        /// Open database connection
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Close database connection
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// It's start a transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// It's finish a transaction
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// It's throw back a transaction
        /// </summary>
        void RollbackTransaction();
    }
}
