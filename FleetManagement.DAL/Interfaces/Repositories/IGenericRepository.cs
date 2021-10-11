using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class, IBaseClass
    {
        Task<TEntity> GetBy(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null);
        Task<List<TEntity>> GetListBy(
           PagingParameters pagingParameters,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> including = null);
        Task Insert(TEntity entity);
        Task InsertRange(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        Task RemoveById(int id);
        void RemoveRange(ICollection<TEntity> entities);
        void Update(TEntity entitie/*, params Expression<Func<TEntity, object>>[] exclusions*/);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task<List<int>> GetIds(int id);
    }
}
