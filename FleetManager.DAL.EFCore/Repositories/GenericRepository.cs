using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseClass
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context) 
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void InsertRange(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.SingleOrDefault(where);
        }

        public IQueryable<TEntity> FindMultiple(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public IQueryable<TEntity> GetAll()
        {
            return  _dbSet; 
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveById(int id)
        {
            var toBeRemoved = GetById(id);
            Remove(toBeRemoved);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> include)
        {
            return _dbSet.Include(include);
        }

        public void UpdateWithExclusion(TEntity entitie, params Expression<Func<TEntity, object>>[] exclusions)
        {
            _dbSet.Update(entitie);

            foreach (var exclusion in exclusions)
            {
                _context.Entry(entitie).Property(exclusion).IsModified = false;
            }
        }

        public void Update(TEntity entitie)
        {
            _dbSet.Update(entitie);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
