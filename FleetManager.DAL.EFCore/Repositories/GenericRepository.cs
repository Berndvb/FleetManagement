using FleetManagement.Domain.Infrastructure.Pagination;
using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Interfaces.Repositories;
using FleetManager.EFCore.Infrastructure;

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
            CancellationToken cancellationToken,
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

        public async Task<List<TEntity>> GetListBy(
            CancellationToken cancellationToken,
            PagingParameters pagingParameters,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            var query = filter == null 
                ? _dbSet.AsQueryable() 
                : _dbSet.Where(filter);

            if (including != null)
                query = including(query);

            if (pagingParameters != null)
                return await query.GetPaginatedAsync(pagingParameters.PageNumber, pagingParameters.PageSize, cancellationToken);

            return await query.ToListAsync();
        }

        public async Task Insert(CancellationToken cancellationToken, TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task InsertRange(CancellationToken cancellationToken, ICollection<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Remove(CancellationToken cancellationToken, TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task RemoveById(CancellationToken cancellationToken, int id)
        {
            var toBeRemoved = await GetBy(cancellationToken, x => x.Id.Equals(id));
            Remove(cancellationToken, toBeRemoved);
        }

        public void RemoveRange(CancellationToken cancellationToken, ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(CancellationToken cancellationToken, TEntity entitie/*, params Expression<Func<TEntity, object>>[] exclusions*/)
        {
            _dbSet.Update(entitie);

            //foreach (var exclusion in exclusions)
            //{
            //    _context.Entry(entitie).Property(exclusion).IsModified = false; 
            //}
        }

        public void UpdateRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public async Task<List<int>> GetIds(CancellationToken cancellationToken, int id) 
        {
            var ids = await _dbSet
                .Where(x => x.Id.Equals(id))
                .Select(x => x.Id)
                .ToListAsync();

            return ids;
        }
    }
}
