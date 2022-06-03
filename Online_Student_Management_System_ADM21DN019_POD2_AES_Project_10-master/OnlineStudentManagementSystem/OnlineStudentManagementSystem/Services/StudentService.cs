using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{

    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _unitOfWork.Repository<Student>().GetListAsync(orderBy: a => a.OrderBy(b => b.StudentName),
                                                  includeProperties: "AddressCode,Course");
        }
        
        public async Task<Student> GetById(int id)
        {
            return await _unitOfWork.Repository<Student>().GetAsync(filter: a => a.StudentId == id,
                                                      orderBy: a => a.OrderBy(b => b.StudentName),
                                                      includeProperties: "AddressCode,Course");
        }
        public async Task CreateStudent(Student student)
        {
            await _unitOfWork.Repository<Student>().Add(student);
            await _unitOfWork.CompleteAsync();

        }
        public async Task UpdateStudent(int id, Student student)
        {
            //await _unitOfWork.Student.Upsert(student);


            var existingStudent = await GetById(student.StudentId);

            if (existingStudent == null)
                await _unitOfWork.Repository<Student>().Add(student);

            existingStudent.StudentName = student.StudentName;
            existingStudent.CourseId = student.CourseId;
            existingStudent.AddressCodeId = student.AddressCodeId;
            existingStudent.DOB = student.DOB;
            await _unitOfWork.CompleteAsync();

        }
        public async Task DeleteStudent(int id)
        {
           
            await _unitOfWork.Repository<Student>().Delete(id);
            await _unitOfWork.CompleteAsync();
        }

    }

}

