using System.Data;

namespace StudiesAPI.Data
{
    public interface IDapperDatabaseConnector : IDisposable
    {
        IDbConnection Connection { get; }

        void ConnectToDatabase();

        IDbTransaction BeginTransaction();
    }
}
