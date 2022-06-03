using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Models
{
    [Table("Courses")]
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        [Column("CourseName", TypeName = "varchar")]
        [MaxLength(50)]
        [Required]
        public string CourseName { get; set; }

       
    }
}
