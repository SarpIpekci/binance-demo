using BinanceReactDemo.Core.Enumerations;
using System.Data;
using System.Globalization;

namespace BinanceReactDemo.DataAccessLayer
{
    public class RepositoryBase
    {
        protected readonly IDbConnection DbConnection;

        protected readonly IDbTransaction? DbTransaction;

        public readonly byte DeletedRowState = Convert.ToByte(RowState.Deleted, CultureInfo.InvariantCulture);

        public RepositoryBase(IDbConnection dbConnection, IDbTransaction? dbTransaction)
        {
            DbConnection = dbConnection;
            DbTransaction = dbTransaction;
        }
    }
}
