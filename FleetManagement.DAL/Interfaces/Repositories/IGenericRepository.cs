using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace FleetManagement.Domain.Interfaces.Repositories
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
        Task Insert(CancellationToken cancellationToken, TEntity entity);
        Task InsertRange(CancellationToken cancellationToken, ICollection<TEntity> entities);
        void Remove(CancellationToken cancellationToken, TEntity entity);
        Task RemoveById(CancellationToken cancellationToken, int id);
        void RemoveRange(CancellationToken cancellationToken, ICollection<TEntity> entities);
        Task Update(CancellationToken cancellationToken, TEntity entitie);
        Task UpdateById(CancellationToken cancellationToken,int id,TEntity updatedEntity,Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null);
        void UpdateRange(CancellationToken cancellationToken, IEnumerable<TEntity> entities);
        Task<List<int>> GetIds(CancellationToken cancellationToken, int id);
    }
}
