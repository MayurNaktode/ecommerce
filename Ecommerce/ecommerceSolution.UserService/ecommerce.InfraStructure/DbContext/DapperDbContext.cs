using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace ecommerce.InfraStructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection _dbConnection;
        public DapperDbContext(IConfiguration config)
        {
           
            _config = config;
            string? conn = _config.GetConnectionString("PostgresConnection").ToString();

            // Create new npgSQL connection;

            _dbConnection  = new NpgsqlConnection(conn);
        }


        public IDbConnection DbConnection => _dbConnection;
    }
}
