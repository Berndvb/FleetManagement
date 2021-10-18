using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace FleetManager.EFCore.Repositories
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class, IBaseClass
    {
        Task<TEntity> GetBy(
             CancellationToken cancellationToken,
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null);
        Task<List<TEntity>> GetListBy(
            CancellationToken cancellationToken,
            PagingParameters pagingParameters = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null);
        Task Insert(TEntity entity, CancellationToken cancellationToken);
        Task InsertRange(ICollection<TEntity> entities, CancellationToken cancellationToken);
        Task Remove(TEntity entity, CancellationToken cancellationToken);
        Task RemoveById(int id, CancellationToken cancellationToken);
        Task RemoveRange(ICollection<TEntity> entities, CancellationToken cancellationToken);
        Task Update(TEntity entityNew, CancellationToken cancellationToken);
        Task<List<int>> GetIds(int id, CancellationToken cancellationToken);
    }
}
