using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FleetManager.Dapper.Infrastructure
{
    public class DapperContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
