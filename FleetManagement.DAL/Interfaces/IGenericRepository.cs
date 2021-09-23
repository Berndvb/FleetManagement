using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FleetManager.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        ICollection<TType> Select<TType>(Expression<Func<TEntity, TType>> select);
        ICollection<TType> FindAndSelect<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select);
        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveById(int id);
        void RemoveRange(ICollection<TEntity> entities);
        IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
