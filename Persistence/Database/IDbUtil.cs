using Dapper;
using Npgsql;

namespace Quotation.Persistence.Database
{
    public interface IDbUtil
    {
        public abstract NpgsqlConnection GetConnection();
        public abstract Task<int> Save(string query, DynamicParameters parameters);
    }
}
