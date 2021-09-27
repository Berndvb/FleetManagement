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

        public async Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.SingleOrDefaultAsync(where);
        }

        public async Task<ICollection<TEntity>> FindMultiple(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public async Task<ICollection<TType>> Select<TType>(Expression<Func<TEntity, TType>> select)
        {
            return await _dbSet.Select(select).ToListAsync();
        }

        public async Task<ICollection<TType>> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return await _dbSet.Where(where).Select(select).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync(); 
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            await Remove(await GetById(id));
        }

        public async Task RemoveRange(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<ICollection<TEntity>> Include(params Expression<Func<TEntity, object>>[] includes)
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

            return query == null ? await _dbSet.ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdWithIncludes(int id, params Expression<Func<TEntity, object>>[] includes) 
        {
            IIncludableQueryable<TEntity, object> query = (IIncludableQueryable<TEntity, object>)await _dbSet.FindAsync(id);

            if (includes.Length > 0)
            {
                query.Include(includes[0]);
            }

            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return (TEntity)query;
        }

        public async Task<ICollection<TEntity>> FindWithIncludes(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            IIncludableQueryable<TEntity, object> query = (IIncludableQueryable<TEntity, object>)_dbSet.Where(where);

            if (includes.Length > 0)
            {
                query.Include(includes[0]);
            }

            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return await query.ToListAsync();
        }
    }
}
