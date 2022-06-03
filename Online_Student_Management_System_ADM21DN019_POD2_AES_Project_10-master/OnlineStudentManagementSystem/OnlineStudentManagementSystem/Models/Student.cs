using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStudentManagementSystem.Models
{
    [Table("Students")]
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        [Column("StudentName", TypeName = "varchar")]
        [MaxLength(50)]
        [Required]
        public string StudentName { get; set; }
       
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [Required]
        [ForeignKey("AddressCode")]
        public int AddressCodeId { get; set; }
       
      
        [Required]
        public DateTime DOB { get; set; }
        public virtual AddressCode AddressCode { get; set; }
        public virtual Course Course { get; set; }




       

    }
}
