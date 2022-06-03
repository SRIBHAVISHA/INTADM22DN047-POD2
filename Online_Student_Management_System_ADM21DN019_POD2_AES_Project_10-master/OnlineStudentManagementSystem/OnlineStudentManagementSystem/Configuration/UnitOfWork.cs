using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Repository;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StudentDBContext _context;
        private readonly ILogger _logger;
        private Hashtable _repositories;

        
       
       



       
        public UnitOfWork(StudentDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

          
           
          
            
        }

        
        

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public  void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context, _logger);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}