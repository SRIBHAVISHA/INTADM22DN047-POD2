using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Admin>> Get()
        {
            return await _unitOfWork.Repository<Admin>().All();
        }
        public async Task<Admin> GetById(int id)
        {
            return await _unitOfWork.Repository<Admin>().GetById(id);
        }
        public async Task CreateAdmin(Admin admin)
        {
            await _unitOfWork.Repository<Admin>().Add(admin);
            await _unitOfWork.CompleteAsync();

        }
        public async Task DeleteAdmin(int id)
        {
            await _unitOfWork.Repository<Admin>().Delete(id);
            await _unitOfWork.CompleteAsync();
        }

    }


}
