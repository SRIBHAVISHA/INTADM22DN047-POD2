using OnlineStudentManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStudentManagementSystem.DTO
{

    public class StudentDTO
    {

       
      
        [MaxLength(50)]
        [Required]
        public string StudentName { get; set; }
       
       
       
      
        [Required]
        public DateTime DOB { get; set; }
        public virtual AddressCodeDTO AddressCode { get; set; }
        public virtual CourseDTO Course { get; set; }




       

    }
}
