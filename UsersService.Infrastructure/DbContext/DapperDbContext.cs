using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace UsersService.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString =
                _configuration.GetConnectionString("PostgreSQL") ?? string.Empty;

            connectionString = connectionString
                .Replace("$DATABASE_HOST", _configuration["DATABASE_HOST"] ?? string.Empty)
                .Replace("$DATABASE_NAME", _configuration["DATABASE_NAME"] ?? string.Empty)
                .Replace("$DATABASE_USER", _configuration["DATABASE_USER"] ?? string.Empty)
                .Replace("$DATABASE_PASSWORD", _configuration["DATABASE_PASSWORD"] ?? string.Empty)
                .Replace("$DATABASE_PORT", _configuration["DATABASE_PORT"] ?? string.Empty);

            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection Connection => _connection;
    }
}
