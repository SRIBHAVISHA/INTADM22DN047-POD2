using OnlineStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Services
{
   public interface ISubjectReportCardService
    {
        Task<IEnumerable<SubjectReportCard>> Get();
        Task<SubjectReportCard> GetById(int id);
        Task CreateSubjectReportCard(SubjectReportCard subjectReportCard);
        Task DeleteSubjectReportCard(int id);
        Task UpdateSubjectReportCard(int id, SubjectReportCard subjectReportCard);

    }
}
