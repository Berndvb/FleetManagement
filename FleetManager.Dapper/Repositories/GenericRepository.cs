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

        public async Task<IEnumerable<TOutput>> GetAll<TInput, TOutput>(TInput input, TOutput output)
        {
            var queryString = "SELECT * FROM @output";

            return await QueryWithResult<TInput, TOutput>(input, queryString);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            Remove(GetById(id));
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
