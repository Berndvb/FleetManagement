using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<ICollection<TEntity>> GetAll();
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        ICollection<TType> Select<TType>(Expression<Func<TEntity, TType>> select);
        ICollection<TType> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveById(int id);
        Task RemoveRange(ICollection<TEntity> entities);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdWithIncludesAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<ICollection<TEntity>> FindWithIncludesAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    }
}
