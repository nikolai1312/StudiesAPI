using Dapper;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Data.Repositories
{
    public class AttendedFansRepository : IAttendedFansRepository
    {
        private readonly DapperDatabaseConnector _connection;

        public AttendedFansRepository(DapperDatabaseConnector connection)
        {
            _connection = connection;
        }

        public async Task CreateAsync(AttendedFans entity)
        {
            _connection.ConnectToDatabase();
            var _transaction = _connection.BeginTransaction();
            try
            {
                var _values = new { AttendedGuests = entity.AttendedGuests, ConcertId = entity.ConcertId };
                string sqlQuery = @$"INSERT INTO Attended_Fans(attended_fans, concert_fk_id)
                                     VALUES(@AttendedGuests, @ConcertId)";
                await _connection.Connection.ExecuteAsync(sqlQuery, param: _values, _transaction);
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            _connection.Dispose();
        }

        public Task DeleteAsync(AttendedFans entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AttendedFans>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AttendedFans> GetAsync(int id)
        {
            _connection.ConnectToDatabase();
            string _sqlQuery = @$"
                    SELECT *
                    FROM Attended_Fans
                    WHERE Id = {id}
                ";

            var _result = await _connection.Connection.QueryFirstOrDefaultAsync<AttendedFans>(_sqlQuery, param: new { id });
            _connection.Dispose();
            return _result;
        }
    }
}
