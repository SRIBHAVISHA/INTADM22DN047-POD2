using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository

{
    public class AddressCodeRepository : GenericRepository<AddressCode>, IAddressCodeRepository
    {
        public AddressCodeRepository(StudentDBContext context, ILogger logger) : base(context, logger)
        {
        }
       
        public override async Task<IEnumerable<AddressCode>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(AddressCodeRepository));
                return new List<AddressCode>();
            }
        }
        public override async Task<bool> Upsert(AddressCode entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.AddressCodeId == entity.AddressCodeId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.City = entity.City;
                existingUser.State = entity.State;
                existingUser.ZipCode = entity.ZipCode;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(AddressCodeRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.AddressCodeId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AddressCodeRepository));
                return false;
            }
        }
    }
}
