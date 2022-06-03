using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected StudentDBContext context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(StudentDBContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;

        }

        public async virtual Task<IEnumerable<T>> All()
        {

            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(GenericRepository <T>));
                return new List<T>();
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual  Task<bool> Delete(int id)
        {
          
            T entity =  dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return Task.FromResult(true);

            }
            return Task.FromResult(false);
           
           
        }
       

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<T> GetAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}