using Microsoft.Data.SqlClient;
using System.Data;

namespace _18_DapperExample.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // DB bağlantısı oluşturan method

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
