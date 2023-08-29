using MySql.Data.MySqlClient;
using System.Data;

namespace StudiesAPI.Data
{
    public class DapperDatabaseConnector
    {
        private readonly string _connectionString;

        public DapperDatabaseConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection ConnectToDatabase()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
