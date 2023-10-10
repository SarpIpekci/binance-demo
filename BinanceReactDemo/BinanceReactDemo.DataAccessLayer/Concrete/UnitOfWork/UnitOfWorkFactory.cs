using BinanceReactDemo.Core.Extensions;
using BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace SmartAdmin.DotNetSix.DataAccess.Concrete.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWorkFactory(ILogger<UnitOfWork> logger)
        {
            _logger = logger;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(new SqlConnection(ConfigurationExtension.GetConnectionString()), _logger);
        }
    }
}
