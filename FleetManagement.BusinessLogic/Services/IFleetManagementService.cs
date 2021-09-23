using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FleetManagement.BLL.Services
{
    public interface IFleetManagementService<TEntity>
    {
        TEntity GetById(string id);
        List<TEntity> GetAll();
        List<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        ICollection<TType> Select<TType>(Expression<Func<TEntity, TType>> select);
        ICollection<TType> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class;
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveById(int id);
        void RemoveRange(List<TEntity> entities);
        List<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
