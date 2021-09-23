using Dapper;
using FleetManager.Dapper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public class MainGenericRepository <TEntity> where TEntity : class
    {
        private readonly DapperContextFactory _dapperContextFactory;

        public MainGenericRepository(DapperContextFactory dapperContextFactory)
        {
            _dapperContextFactory = dapperContextFactory;
        }

        public Task Command(DynamicParameters parameters, string queryText) 
           => WithConnection(async connectionmethod =>
           {
               await connectionmethod.ExecuteAsync(queryText, parameters);
           });

        public Task<TEntity> QuerySingleResult(DynamicParameters parameters, string queryText)
            => WithConnection<TEntity>(async connectionmethod =>
            {
                var result = await connectionmethod.QueryAsync<TEntity>(queryText, parameters);

                return result.SingleOrDefault();
            });

        public Task<IEnumerable<TEntity>> QueryMultipleResult(DynamicParameters parameters, string queryText)
           => WithConnection<IEnumerable<TEntity>>(async connectionmethod =>
           {
               var result = await connectionmethod.QueryAsync<TEntity>(queryText, parameters);

               return result;
           });

        private async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> connectionMethod)
        {
            using (var connection = _dapperContextFactory.CreateConnection())
            {
                connection.Open();

                return await connectionMethod(connection);
            }
        }

        private async Task WithConnection(Func<IDbConnection, Task> connectionMethod)
        {
            using (var connection = _dapperContextFactory.CreateConnection())
            {
                connection.Open();
                await connectionMethod(connection);
            }
        }
    }
}
