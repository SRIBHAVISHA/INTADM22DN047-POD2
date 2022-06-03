using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> Get();
        Task<Admin> GetById(int id);
        Task CreateAdmin(Admin admin);
        Task DeleteAdmin(int id);
    }
}
