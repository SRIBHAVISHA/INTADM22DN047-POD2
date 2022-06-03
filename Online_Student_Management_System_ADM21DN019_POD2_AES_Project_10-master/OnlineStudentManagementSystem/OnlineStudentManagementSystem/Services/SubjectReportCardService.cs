using OnlineStudentManagementSystem.Configuration;
using OnlineStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
    public class SubjectReportCardService : ISubjectReportCardService
    {
        private readonly IUnitOfWork _unitOfWork;

    public SubjectReportCardService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SubjectReportCard>> Get()
    {
            return await _unitOfWork.Repository<SubjectReportCard>().GetListAsync(orderBy: a => a.OrderBy(b => b.Marks),
                                                      includeProperties: "Subject,Student");
        }
     
        public async Task<SubjectReportCard> GetById(int id)
        {
            return await _unitOfWork.Repository<SubjectReportCard>().GetAsync(filter: a => a.SubjectReportCardId == id,
                                                      orderBy: a => a.OrderBy(b => b.Marks),
                                                      includeProperties: "Subject,Student");
        }
        public async Task CreateSubjectReportCard(SubjectReportCard subjectReportCard)
    {
        await _unitOfWork.Repository<SubjectReportCard>().Add(subjectReportCard);
        await _unitOfWork.CompleteAsync();

    }
        public async Task UpdateSubjectReportCard(int id,SubjectReportCard subjectReportCard)
        {
            var existingSubjectReportCard = await GetById(subjectReportCard.SubjectReportCardId);

            if (existingSubjectReportCard == null)


                existingSubjectReportCard.StudentId = subjectReportCard.StudentId;
            existingSubjectReportCard.SubjectId = subjectReportCard.SubjectId;
            existingSubjectReportCard.Marks = subjectReportCard.Marks;
            await _unitOfWork.Repository<SubjectReportCard>().Add(subjectReportCard);

            await _unitOfWork.CompleteAsync();
        }
        public async Task DeleteSubjectReportCard(int id)
    {
        await _unitOfWork.Repository<SubjectReportCard>().Delete(id);
        await _unitOfWork.CompleteAsync();
    }
   

}
}
