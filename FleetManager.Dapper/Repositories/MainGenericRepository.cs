using Dapper;
using FleetManager.Dapper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public class MainGenericRepository
    {
        private readonly DapperContextFactory _dapperContextFactory;

        public MainGenericRepository(DapperContextFactory dapperContextFactory)
        {
            _dapperContextFactory = dapperContextFactory;
        }

        public Task Command<TEntity>(TEntity entity, string queryText) // queryText will probably need a $ or @
           => WithConnection(async connectionmethod =>
           {
               await connectionmethod.ExecuteAsync(queryText, entity);
           });

        public Task<TEntity> QuerySingleResult<TEntity>(TEntity entity, string queryText)
            => WithConnection<TEntity>(async connectionmethod =>
            {
                var result = await connectionmethod.QueryAsync<TEntity>(queryText, entity);

                return result.SingleOrDefault();
            });

        public Task<IEnumerable<TEntity>> QueryMultipleResult<TEntity>(TEntity entity, string queryText)
           => WithConnection<IEnumerable<TEntity>>(async connectionmethod =>
           {
               var result = await connectionmethod.QueryAsync<TEntity>(queryText, entity);
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
