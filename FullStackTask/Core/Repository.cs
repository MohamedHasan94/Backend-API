using FullStackTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(TContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _entities.Add(entity);
            return _context.SaveChanges() > 0 ? entity : null;
        }

        public virtual List<TEntity> AddRange(List<TEntity> entities)
        {
            _entities.AddRange(entities);
            return _context.SaveChanges() > 0 ? entities : null;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual List<TEntity> GetAllBind()
        {
            return _entities.ToList();
        }


        public virtual PaginatedList<TEntity> GetPaged(string sortOrder, string currentFilter, string searchString, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(params object[] id)
        {
            return _entities.Find(id);
        }

        public virtual bool Remove(TEntity entity)
        {
            if (!_entities.Contains(entity)) return false;

            _entities.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Remove(params object[] id)
        {
            TEntity ent = _entities.Find(id);
            if (ent == null) return false;

            _entities.Remove(ent);
            return _context.SaveChanges() > 0;
        }

        public virtual bool RemoveRange(List<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            return _context.SaveChanges() > 0;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (!_entities.Contains(entity)) return null;

            _entities.Update(entity);
            return _context.SaveChanges() > 0 ? entity : null;
        }

        public virtual List<TEntity> UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!_entities.Contains(entity)) return null;
            }

            _entities.UpdateRange(entities);
            return _context.SaveChanges() > 0 ? entities : null;
        }
    }
}