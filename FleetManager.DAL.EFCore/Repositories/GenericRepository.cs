using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.EFCore.Infrastructure;
using FleetManagement.Framework.Paging;
using FleetManager.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : class, IBaseClass
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Task<TEntity> GetBy(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            var query = filter == null 
                ? _dbSet.AsQueryable() 
                : _dbSet.Where(filter);

            if (including != null)
                query = including(query);

            return query.SingleOrDefaultAsync();
        }

        public Task<List<TEntity>> GetListBy(
            PagingParameters pagingParameters,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            var query = filter == null 
                ? _dbSet.AsQueryable() 
                : _dbSet.Where(filter);

            if (including != null)
                query = including(query);

            query = pagingParameters == null 
                ? query
                : query
                    .OrderBy(x => x.Id)
                    .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                    .Take(pagingParameters.PageSize);

            return query.ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task InsertRange(ICollection<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task RemoveById(int id)
        {
            var toBeRemoved = await GetBy(x => x.Id.Equals(id));
            Remove(toBeRemoved);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entitie/*, params Expression<Func<TEntity, object>>[] exclusions*/)
        {
            _dbSet.Update(entitie);

            //foreach (var exclusion in exclusions)
            //{
            //    _context.Entry(entitie).Property(exclusion).IsModified = false; 
            //}
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task<List<int>> GetIds(int id) 
        {
            var ids = await _dbSet
                .Where(x => x.Id.Equals(id))
                .Select(x => x.Id)
                .ToListAsync();

            return ids;
        }
    }
}
