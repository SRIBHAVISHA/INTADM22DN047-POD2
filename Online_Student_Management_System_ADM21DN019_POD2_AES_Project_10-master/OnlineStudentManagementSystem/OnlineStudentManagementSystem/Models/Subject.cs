using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Models
{
    [Table("Subjects")]
    public class Subject
    {

        [Key]
        public int SubjectId { get; set; }
        [Required]
        [Column("SubjectName", TypeName = "varchar")]
        [MaxLength(20)]
        public string SubjectName { get; set; }
        
       
       
        
    }
}
