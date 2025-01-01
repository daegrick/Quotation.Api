using Dapper;
using Npgsql;

namespace Quotation.Persistence.Database
{
    public interface IDbUtil
    {
        public abstract NpgsqlConnection GetConnection();
        public abstract Task<int> Save(UpsertBuilder upsert);
        public abstract Task<T> Get<T>(SelectBuilder select) where T : class, new();
    }
}
