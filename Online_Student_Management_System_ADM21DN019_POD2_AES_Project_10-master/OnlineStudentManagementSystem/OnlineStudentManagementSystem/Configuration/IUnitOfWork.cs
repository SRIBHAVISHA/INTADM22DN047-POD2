using OnlineStudentManagementSystem.Repository;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Configuration
{
    public interface IUnitOfWork
    {

       // IAdminRepository Admin { get; }
       
       
       
      

        IGenericRepository<T> Repository<T>() where T : class;
        Task CompleteAsync();



        void Dispose();
    }
}
