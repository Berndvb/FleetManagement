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
        Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> where);
        Task<ICollection<TEntity>> FindMultiple(Expression<Func<TEntity, bool>> expression);
        Task<ICollection<TType>> Select<TType>(Expression<Func<TEntity, TType>> select);
        Task<ICollection<TType>> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        Task RemoveById(int id);
        void RemoveRange(ICollection<TEntity> entities);
        Task<ICollection<TEntity>> Include(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdWithIncludes(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<ICollection<TEntity>> FindWithIncludes(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    }
}
