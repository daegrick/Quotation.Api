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

        public async Task<int> Save(string query, DynamicParameters parameters) => await GetConnection().ExecuteAsync(query, parameters);
    }
}
