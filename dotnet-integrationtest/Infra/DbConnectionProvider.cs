using System;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Options;
using dotnet_integrationtest.Infra.Config;

namespace dotnet_integrationtest.Infra
{
	public class DbConnectionProvider : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DbConnectionProvider(IOptions<ConnectionStrings> connections)
        {
            _connectionString = connections.Value.PostgreSQL;
        }

        public IDbConnection GetConnection()
        {
            _connection = new NpgsqlConnection(_connectionString);
            _connection.Open();
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}

