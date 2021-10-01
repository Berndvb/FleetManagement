﻿using FleetManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseClass
    {
        Task<TEntity> GetBy(
            Expression<Func<TEntity, bool>> filter = null,
            params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] including);
        Task<List<TEntity>> GetListBy(
            Expression<Func<TEntity, bool>> filter = null,
            params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] including);
        Task Insert(TEntity entity);
        Task InsertRange(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        Task RemoveById(int id);
        void RemoveRange(ICollection<TEntity> entities);
        void Update(TEntity entitie, params Expression<Func<TEntity, object>>[] exclusions);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
