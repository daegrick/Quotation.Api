using Dapper;
using Npgsql;

namespace Quotation.Persistence.Database
{
    public class DbUtil : IDbUtil
    {
        public readonly NpgsqlConnection Connection;

        public DbUtil()
        {
            Connection = GetConnection();
        }

        public NpgsqlConnection GetConnection()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = "host.docker.internal",
                Port = 5432,
                Database = "quotation",
                Username = "postgres",
                Password = "password"
            };
            return new NpgsqlConnection(builder.ConnectionString);
        }

        public async Task<T> Get<T>(SelectBuilder select) where T : class, new() => await GetConnection().QuerySingleOrDefaultAsync<T>(select.ToString(), select.Parameters) ?? new();

        public async Task<int> Save(UpsertBuilder upsert) => await GetConnection().ExecuteAsync(upsert.ToString(), upsert.Parameters);
    }
}
