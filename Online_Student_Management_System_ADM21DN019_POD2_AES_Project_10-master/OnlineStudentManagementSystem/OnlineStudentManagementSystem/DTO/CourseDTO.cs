using System.ComponentModel.DataAnnotations;

namespace OnlineStudentManagementSystem.DTO
{
    public class CourseDTO
    {
        [MaxLength(50)]
        [Required]
        public string CourseName { get; set;}
    }
}
    