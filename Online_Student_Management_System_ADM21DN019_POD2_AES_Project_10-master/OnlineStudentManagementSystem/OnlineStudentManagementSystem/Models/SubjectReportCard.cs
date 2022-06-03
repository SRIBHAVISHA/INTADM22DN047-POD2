using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Models
{

    [Table("SubjectReportCards")]
    public class SubjectReportCard
    {

        [Key]
        public int SubjectReportCardId { get; set; }
      
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
       
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public int Marks { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }


    }
}
