using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        
        Task<bool> Upsert(T entity);
        Task<IEnumerable<T>> GetListAsync(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "");

        Task<T> GetAsync(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "");
    }
}