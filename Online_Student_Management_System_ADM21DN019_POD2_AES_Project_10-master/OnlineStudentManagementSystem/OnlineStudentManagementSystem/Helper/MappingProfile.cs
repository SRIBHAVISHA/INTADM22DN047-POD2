using AutoMapper;
using OnlineStudentManagementSystem.DTO;
using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<AddressCode, AddressCodeDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<SubjectReportCard, SubjectReportCardDTO>().ReverseMap();


        }
    }
}
