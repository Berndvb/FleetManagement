using FleetManagement.EFCore.Infrastructure;
using FleetManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context) //open context via 'using' for better disposing?
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }
        public ICollection<TType> Select<TType>(Expression<Func<TEntity, TType>> select)
        {
            return _dbSet.Select(select).ToList();
        }

        public ICollection<TType> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _dbSet.Where(where).Select(select).ToList();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            Remove(await GetById(id));
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes) // lacks ToList() - carefull
        {
            IIncludableQueryable<TEntity, object> query = null;

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
