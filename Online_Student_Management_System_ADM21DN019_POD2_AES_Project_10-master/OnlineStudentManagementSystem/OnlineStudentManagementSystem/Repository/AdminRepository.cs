using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(StudentDBContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Admin>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(AdminRepository));
                return new List<Admin>();
            }
        }
        public override async Task<bool> Upsert(Admin entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.AdminId == entity.AdminId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.AdminUserName = entity.AdminUserName;
                existingUser.Password = entity.Password;
               
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(AdminRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.AdminId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AdminRepository));
                return false;
            }
        }
    }
}
