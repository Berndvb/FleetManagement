using FleetManager.Dapper.Infrastructure;
using FleetManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public class GenericRepository : MainGenericRepository
    {
        public GenericRepository(DapperContextFactory dapperContextFactory) : base(dapperContextFactory)
        {
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>(TEntity entity) // CHECK
        {
            var sb = new StringBuilder();
            sb.Append
            var queryString = "SELECT * FROM @entity";

            return await QueryMultipleResult<TEntity>(entity, queryString);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task Remove<TEntity>(TEntity entity) // Check
        {
            var queryString = "DELETE @entity";

            await Command<TEntity>(entity, queryString);
        }

        public async Task RemoveById<TEntity>(TEntity entity, int id) // Check
        {
            var queryString = "DELETE @entity WHERE Id = @Id";

            await Command<TEntity>(entity, queryString);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IIncludableQueryable<T, object> query = null;

            if (includes.Length > 0)
            {
                query = _dbSet.Include(includes[0]);
            }

            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? _dbSet : query;
        } 
    }
}
