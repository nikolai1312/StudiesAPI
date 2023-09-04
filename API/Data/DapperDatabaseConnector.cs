using MySql.Data.MySqlClient;
using System.Data;

namespace StudiesAPI.Data
{
    public class DapperDatabaseConnector : IDapperDatabaseConnector
    {
        private MySqlConnection _connection;

        public DapperDatabaseConnector(IConfiguration config)
        {
            _connection = new MySqlConnection(config.GetConnectionString("Default"));
        }

        public virtual IDbConnection Connection 
        {
            get
            { 
                ConnectToDatabase();
                return _connection; 
            } 
        }

        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public void ConnectToDatabase()
        {
            if (_connection.State != ConnectionState.Open) 
            {
                _connection.Open();    
            }
        }

        public void Dispose()
        {
            if(_connection.State != ConnectionState.Closed) 
            {
                _connection.Close();
            }
        }
    }
}
