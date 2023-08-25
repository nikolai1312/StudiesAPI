using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Npgsql;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;
using System.Data;

namespace StudiesAPI.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly MySqlConnection _connection;
        public GuestRepository()
        {
            _connection = new MySqlConnection("Server=localhost;Port=3306;Database=amigos-do-bem-db;Uid=root;Pwd=newbies2023;");
            _connection.Open();
        }

        public async Task CreateAsync(Guest entity)
        {
                var _transaction = await _connection.BeginTransactionAsync();
                try
                {
                    var _guest = new { CPF = entity.CPF, Name = entity.Name};
                    string sqlQuery = @$"INSERT INTO Guests(name, cpf)
                                         VALUES(@Name, @CPF)";
                   await _connection.ExecuteAsync(sqlQuery, param: _guest, _transaction);
                    _transaction.Commit();
                }
                catch
                {
                    _transaction.Rollback();
                    throw;
                }
        }

        public async Task DeleteAsync(Guest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            string _sqlQuery = @$"
                    SELECT *
                    FROM Guests
                ";

            var _result = await _connection.QueryAsync<Guest>(_sqlQuery);
            return _result;
        }

        public async Task<Guest> GetAsync(int Id)
        {

            string _sqlQuery = @$"
                    SELECT *
                    FROM Guests
                    WHERE Id = { Id }
                ";

            var _result = await _connection.QueryFirstOrDefaultAsync<Guest>(_sqlQuery, param: new { Id });
            return _result;
        }
    }
}
