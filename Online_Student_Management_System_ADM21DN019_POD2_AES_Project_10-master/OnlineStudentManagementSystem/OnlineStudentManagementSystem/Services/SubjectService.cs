using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subject>> Get()
        {
            return await _unitOfWork.Repository<Subject>().All();
        }
        public async Task<Subject> GetById(int id)
        {
            return await _unitOfWork.Repository<Subject>().GetById(id);
        }
        public async Task CreateSubject(Subject subject)
        {
            await _unitOfWork.Repository<Subject>().Add(subject);
            await _unitOfWork.CompleteAsync();
        }
        public async Task UpdateSubject(int id, Subject subject)
        {
            var existingSubject = await GetById(subject.SubjectId);
            if (existingSubject == null)

<<<<<<< HEAD
                await _unitOfWork.Repository<Subject>().Upsert(subject);
=======
                await _unitOfWork.Repository<Subject>().Add(subject);
>>>>>>> OnlineStudentManagement_UI
           
           
              

            existingSubject.SubjectName = subject.SubjectName;
            await _unitOfWork.CompleteAsync();

        }
        public async Task DeleteSubject(int id)
        {
            await _unitOfWork.Repository<Subject>().Delete(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}

