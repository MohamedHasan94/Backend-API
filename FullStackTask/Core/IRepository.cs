using FullStackTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Core
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        List<TEntity> GetAllBind();

        PaginatedList<TEntity> GetPaged(string sortOrder, string currentFilter, string searchString, int pageNumber);

        TEntity GetById(params object[] id);

        TEntity Add(TEntity entity);

        List<TEntity> AddRange(List<TEntity> entity);

        TEntity Update(TEntity entity);
        List<TEntity> UpdateRange(List<TEntity> entity);

        bool Remove(TEntity entity);
        bool Remove(params object[] id);

        bool RemoveRange(List<TEntity> entities);
    }
}