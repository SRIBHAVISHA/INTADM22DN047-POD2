using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> Get()
        {
            return await _unitOfWork.Repository<Course>().All();
        }
        public async Task<Course> GetById(int id)
        {
            return await _unitOfWork.Repository<Course>().GetById(id);
        }
        public async Task CreateCourse(Course course)
        {
            await _unitOfWork.Repository<Course>().Add(course);
            await _unitOfWork.CompleteAsync();

        }
        public async Task UpdateCourse(int id, Course course)
        {
            var existingCourse = await GetById(course.CourseId);

            if (existingCourse == null)
                await _unitOfWork.Repository<Course>().Add(course);
            existingCourse.CourseName = course.CourseName;

            await _unitOfWork.CompleteAsync();
            

        }
        public async Task DeleteCourse(int id)
        {
            await _unitOfWork.Repository<Course>().Delete(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}

