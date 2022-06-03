using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Models
{

    [Table("Admins")]
    public class Admin
    {


        [Key]
        public int AdminId { get; set; }
        [Required]
        [Column("AdminUsername", TypeName = "varchar")]
        [MaxLength(20)]
        public string AdminUserName { get; set; }
        [Required]
        [Column("Password", TypeName = "varchar")]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}
