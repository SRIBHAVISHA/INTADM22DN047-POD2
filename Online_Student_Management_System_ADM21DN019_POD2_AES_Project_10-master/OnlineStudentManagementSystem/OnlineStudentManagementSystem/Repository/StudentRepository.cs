using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
         public class StudentRepository : GenericRepository<Student>, IStudentRepository
        {
            public StudentRepository(StudentDBContext context, ILogger logger) : base(context, logger)
            {
            }
            public override async Task<IEnumerable<Student>> All()
            {
                try
                {
                    return await dbSet.ToListAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} All function error", typeof(StudentRepository));
                    return new List<Student>();
                }

            }
            public override async Task<bool> Upsert(Student entity)
            {
                try
                {
                    var existingUser = await dbSet.Where(x => x.StudentId == entity.StudentId)
                                                        .FirstOrDefaultAsync();

                    if (existingUser == null)
                        return await Add(entity);

                    existingUser.StudentName = entity.StudentName;
                    existingUser.CourseId = entity.CourseId;
                    existingUser.AddressCodeId = entity.AddressCodeId;
                    existingUser.DOB = entity.DOB;

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} Upsert function error", typeof(StudentRepository));
                    return false;
                }
            }

            public override async Task<bool> Delete(int id)
            {
                try
                {
                    var exist = await dbSet.Where(x => x.StudentId == id)
                                            .FirstOrDefaultAsync();

                    if (exist == null) return false;

                    dbSet.Remove(exist);

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "{Repo} Delete function error", typeof(StudentRepository));
                    return false;
                }
            }
        }
    }

