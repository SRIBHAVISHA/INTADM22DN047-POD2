using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public class SubjectReportCardRepository : GenericRepository<SubjectReportCard>, ISubjectReportCardRepository
    {
        public SubjectReportCardRepository(StudentDBContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<SubjectReportCard>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(SubjectReportCardRepository));
                return new List<SubjectReportCard>();
            }
        }
        public override async Task<bool> Upsert(SubjectReportCard entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.SubjectReportCardId == entity.SubjectReportCardId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.StudentId = entity.StudentId;
                existingUser.SubjectId = entity.SubjectId;
                existingUser.Marks= entity.Marks;
                


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(SubjectReportCardRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.SubjectReportCardId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SubjectReportCardRepository));
                return false;
            }
        }
    }
}
