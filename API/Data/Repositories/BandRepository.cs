using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Npgsql;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using System.Data;

namespace StudiesAPI.Data.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly DapperDatabaseConnector _connection;

        public BandRepository(DapperDatabaseConnector connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(Band entity)
        {
            _connection.ConnectToDatabase();
            var _transaction = _connection.BeginTransaction();
            try
            {
                var _band = new { Genre = entity.Genre, Name = entity.Name };
                string sqlQuery = @$"INSERT INTO Bands(name, genre)
                                     VALUES(@Name, @Genre)";
                await _connection.Connection.ExecuteAsync(sqlQuery, param: _band, _transaction);
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            _connection.Dispose();
        }

        public async Task DeleteAsync(Band entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Band>> GetAllAsync()
        {
            _connection.ConnectToDatabase();
            string _sqlQuery = @$"
                    SELECT *
                    FROM Bands
                ";
            var _result = await _connection.Connection.QueryAsync<Band>(_sqlQuery);
            _connection.Dispose();
            return _result;
        }

        public async Task<Band> GetAsync(int Id)
        {
            _connection.ConnectToDatabase();
            string _sqlQuery = @$"
                    SELECT *
                    FROM Bands
                    WHERE Id = {Id}
                ";

            var _result = await _connection.Connection.QueryFirstOrDefaultAsync<Band>(_sqlQuery, param: new { Id });
            _connection.Dispose();
            return _result;
        }
    }
}
