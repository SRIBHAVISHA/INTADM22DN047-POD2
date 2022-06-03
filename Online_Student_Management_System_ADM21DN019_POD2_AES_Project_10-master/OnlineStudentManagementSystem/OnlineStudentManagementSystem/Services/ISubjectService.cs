using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> Get();
        Task<Subject> GetById(int id);
        Task CreateSubject(Subject subject);
        Task DeleteSubject(int id);
        Task UpdateSubject(int id, Subject subject);


    }
}
