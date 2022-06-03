using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
   public interface IStudentService
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> GetById(int id);
        Task CreateStudent(Student student);
        Task DeleteStudent(int id);
        Task UpdateStudent(int id, Student student);


    }
}
