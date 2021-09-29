using FleetManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseClass
    {
        void Insert(TEntity entity);
        void InsertRange(ICollection<TEntity> entities);
        TEntity FindSingle(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> FindMultiple(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Remove(TEntity entity);
        void RemoveById(int id);
        void RemoveRange(ICollection<TEntity> entities);
        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> include);
    }
}
