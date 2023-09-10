using System;
using Dapper;
using dotnet_integrationtest.Entities;
using dotnet_integrationtest.Infra.Config;
using dotnet_integrationtest.Infra.Query;
using Microsoft.Extensions.Options;

namespace dotnet_integrationtest.Infra.Repository
{
    public class QuoteRepository
    {
        private readonly DbConnectionProvider _dbProvider;
        public QuoteRepository(DbConnectionProvider dbProvider) =>
                    _dbProvider = dbProvider;


        public async Task<IEnumerable<Quote>> GetAllQuote()
        {
            using var connection = _dbProvider.GetConnection();
            var query = QuoteQuery.ListAll;
            var result = await connection.QueryAsync<Quote>(query);
            return result;
        }
    }
}

