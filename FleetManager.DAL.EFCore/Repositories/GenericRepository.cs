using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManager.EFCore.Infrastructure.DbContext;
using FleetManager.EFCore.Infrastructure.Pagination;

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
            while (!cancellationToken.IsCancellationRequested)
            {
                var query = filter == null
                    ? _dbSet.AsQueryable()
                    : _dbSet.Where(filter);

                if (including != null)
                    query = including(query);

                return query.SingleOrDefaultAsync(cancellationToken);
            }

            return null;
        }

        public async Task<List<TEntity>> GetListBy(
            CancellationToken cancellationToken,
            PagingParameters pagingParameters = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            while (!cancellationToken.IsCancellationRequested)
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

            return null;
        }

        public async Task Insert(TEntity entity, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
                await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task InsertRange(ICollection<TEntity> entities, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
                await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task Remove(TEntity entity, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Run(() => _dbSet.Remove(entity));

            }

        }

        public async Task RemoveById(int id, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var toBeRemoved = await GetBy(cancellationToken, x => x.Id.Equals(id));
                await Remove(toBeRemoved, cancellationToken);
            }
        }

        public async Task RemoveRange(ICollection<TEntity> entities, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
                await Task.Run(() => _dbSet.RemoveRange(entities));
        }

        public async Task Update(TEntity entityNew, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var task = await Task.Run(() => _dbSet.Update(entityNew));
                if (task.State is EntityState.Modified or EntityState.Added)
                    break;
            }
        }

        public async Task<List<int>> GetIds(int id, CancellationToken cancellationToken) 
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var ids = await _dbSet
               .Where(x => x.Id.Equals(id))
               .Select(x => x.Id)
               .ToListAsync();

                return ids;
            }

            return null;
        }
    }
}
