using MySql.Data.MySqlClient;
using System.Data;

namespace StudiesAPI.Data
{
    public class DapperDatabaseConnector : IDapperDatabaseConnector
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;

        public DapperDatabaseConnector(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(connectionString);
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
            if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting) 
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
