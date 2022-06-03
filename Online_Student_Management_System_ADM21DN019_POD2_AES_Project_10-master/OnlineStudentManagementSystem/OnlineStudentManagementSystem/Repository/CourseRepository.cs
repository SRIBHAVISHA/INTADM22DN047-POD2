using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentDBContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Course>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(CourseRepository));
                return new List<Course>();
            }
        }
        public override async Task<bool> Upsert(Course entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.CourseId == entity.CourseId)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.CourseName = entity.CourseName;
                


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(CourseRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.CourseId == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(CourseRepository));
                return false;
            }
        }
    }
}
