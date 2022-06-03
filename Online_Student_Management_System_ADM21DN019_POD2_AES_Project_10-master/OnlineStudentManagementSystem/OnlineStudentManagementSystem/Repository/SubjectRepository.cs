using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(StudentDBContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Subject>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(SubjectRepository));
                return new List<Subject>();
            }
        }
        public override async Task<bool> Upsert(Subject entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.SubjectId == entity.SubjectId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.SubjectName = entity.SubjectName;
                


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(SubjectRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.SubjectId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SubjectRepository));
                return false;
            }
        }
    }
}
