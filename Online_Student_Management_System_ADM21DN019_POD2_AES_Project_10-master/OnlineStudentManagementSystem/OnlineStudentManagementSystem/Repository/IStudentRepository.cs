using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Repository
{
    
    public interface IStudentRepository : IGenericRepository<Student>
{
    }

}