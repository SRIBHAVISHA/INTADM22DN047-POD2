using OnlineStudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStudentManagementSystem.DTO

{
    public class SubjectReportCardDTO
    {

       

        [Required]
        public int Marks { get; set; }
       
        public virtual StudentDTO Student { get; set; }
        public virtual SubjectDTO Subject { get; set; }
       



    }
}
