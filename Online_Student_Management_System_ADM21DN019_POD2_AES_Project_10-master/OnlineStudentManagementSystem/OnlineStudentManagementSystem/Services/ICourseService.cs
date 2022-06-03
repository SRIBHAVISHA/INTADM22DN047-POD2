using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> Get();
        Task<Course> GetById(int id);
        Task CreateCourse(Course course);
        Task DeleteCourse(int id);
        Task UpdateCourse(int id,Course course);
    }
}
