using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.DTO
{
    public class AddressCodeDTO
    {

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Column("ZipCode")]
        public int ZipCode { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
    }
}


