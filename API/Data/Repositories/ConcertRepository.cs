using Dapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using System.Data;

namespace StudiesAPI.Data.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly DapperDatabaseConnector _connection;

        public ConcertRepository(DapperDatabaseConnector connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(Concert entity)
        {
            _connection.ConnectToDatabase();
            var _transaction = _connection.BeginTransaction();
                try
                {
                    var _concert = new { Name = entity.Name, Year = entity.Year, Country = entity.Country};
                    string sqlQuery = @$"INSERT INTO Concerts(name, year, country)
                                         VALUES(@Name, @Year, @Country)";
                    await _connection.Connection.ExecuteAsync(sqlQuery, param: _concert, _transaction);
                    _transaction.Commit();
                }
                catch
                {
                    _transaction.Rollback();
                    throw;
                }
            _connection.Dispose();
        }

        public async Task DeleteAsync(Concert entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Concert>> GetAllAsync()
        {
            _connection.ConnectToDatabase();
            string _sqlQuery = @$"
                    SELECT *
                    FROM Concerts
                    ";
            var _result = await _connection.Connection.QueryAsync<Concert>(_sqlQuery);
            _connection.Dispose();
            return _result;
        }

        public async Task<Concert> GetAsync(int id)
        {
            _connection.ConnectToDatabase();
            string _sqlQuery = @$"
                    SELECT *
                    FROM Concerts
                    WHERE Id = {id}
                ";
            var _result = await _connection.Connection.QueryFirstOrDefaultAsync<Concert>(_sqlQuery, param: new { id });
            return _result;
        }
    }
}
