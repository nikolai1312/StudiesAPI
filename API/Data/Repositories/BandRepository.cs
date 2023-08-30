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
        public BandRepository(DapperDatabaseConnector connectionString)
        {
            _connection = connectionString;
        }

        public async Task CreateAsync(Band entity)
        {
                using(IDbConnection db = _connection.ConnectToDatabase())
            {
                var _transaction = db.BeginTransaction();
                try
                {
                    var _guest = new { Genre = entity.Genre, Name = entity.Name};
                    string sqlQuery = @$"INSERT INTO Guests(name, genre)
                                         VALUES(@Name, @Genre)";
                   await db.ExecuteAsync(sqlQuery, param: _guest, _transaction);
                    _transaction.Commit();
                }
                catch
                {
                    _transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task DeleteAsync(Band entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Band>> GetAllAsync()
        {
            using (IDbConnection db = _connection.ConnectToDatabase())
            { 
                string _sqlQuery = @$"
                        SELECT *
                        FROM Guests
                    ";

                var _result = await db.QueryAsync<Band>(_sqlQuery);
                return _result;
            }
        }

        public async Task<Band> GetAsync(int Id)
        {
            using (IDbConnection db = _connection.ConnectToDatabase())
            { 
                string _sqlQuery = @$"
                        SELECT *
                        FROM Guests
                        WHERE Id = { Id }
                    ";

                var _result = await db.QueryFirstOrDefaultAsync<Band>(_sqlQuery, param: new { Id });
                return _result;
            }
        }
    }
}
