using Dapper;
using FleetManager.Dapper.Infrastructure;
using FleetManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public class GenericRepository<TEntity> : MainGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(DapperContextFactory dapperContextFactory) : base(dapperContextFactory)
        {
        }

        public void Add(T entity)
        {
            string SqlStatement = "Insert Into Customers (FirstName, LastName, Email) Values(@FirstName, @LastName, @Email)";
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var SqlStatement = "SELECT * FROM @TEntity";
            return await QueryMultipleResult(null, SqlStatement);
        }

        public async Task<TEntity> GetById(int id) 
        {
            var SqlStatement = "SELECT * FROM @TEntity WHERE Id = @id";
            var parameters = new DynamicParameters(id);
            return await QuerySingleResult(parameters, SqlStatement);
        }

        public async Task Remove(dynamic entityToDelete)
        {
            int id;
            if (!int.TryParse(entityToDelete.Id, out id))
                throw new Exception("Couldn't parse the Id-variable into an integer datatype (@Remove-method)");

            await RemoveById(id);
        }

        public async Task RemoveById(int id)
        {
            var SqlStatement = "DELETE FROM @entity WHERE Id = @Id";
            var parameters = new DynamicParameters(id);
            await Command(parameters, SqlStatement);
        }

        public async Task RemoveRange(IEnumerable<dynamic> entities)
        {
            List<int> ids = new List<int>();
            foreach (var entity in entities)
            {
                int id;
                if (!int.TryParse(entity.Id, out id))
                    throw new Exception("Couldn't parse the Id-variable into an integer datatype (@Remove-method)");
                ids.Add(id);
            }
            var SqlStatement = "Delete FROM MY_TABLE WHERE Id in @ids";
            var parameters = new DynamicParameters(ids.ToArray());
            await Command(parameters, SqlStatement);
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
