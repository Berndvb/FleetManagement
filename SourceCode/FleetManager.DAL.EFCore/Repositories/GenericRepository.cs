using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using FleetManager.EFCore.Infrastructure.DbContext;
using FleetManager.EFCore.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            var query = filter == null
                ? _dbSet.AsQueryable()
                : _dbSet.Where(filter);

            if (including != null)
                query = including(query);

            return query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetListBy(
            CancellationToken cancellationToken,
            PagingParameters pagingParameters = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null)
        {
            var query = filter == null
                ? _dbSet.AsQueryable()
                : _dbSet.Where(filter);

            if (including != null)
                query = including(query);

            if (pagingParameters != null)
                return await query.GetPaginatedAsync(
                    pagingParameters.PageNumber,
                    pagingParameters.PageSize,
                    cancellationToken);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task Insert(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task InsertRange(ICollection<TEntity> entities, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task Remove(TEntity entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _dbSet.Remove(entity), cancellationToken);
        }

        public async Task Update(TEntity entityNew, CancellationToken cancellationToken)
        {
            await Task.Run(() => _dbSet.Update(entityNew), cancellationToken);
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
