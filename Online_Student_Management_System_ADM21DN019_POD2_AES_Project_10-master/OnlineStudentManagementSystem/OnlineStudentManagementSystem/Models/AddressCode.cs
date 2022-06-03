using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStudentManagementSystem.Models
{
    [Table("AddressCodes")]
    public class AddressCode
    {
            [Key]
            public int AddressCodeId { get; set; }
            [Required]
            [Column("City", TypeName = "varchar")]
            [MaxLength(50)]
            public string City { get; set; }
            [Required]
            [Column("State", TypeName = "varchar")]
            [MaxLength(50)]
            public string State { get; set; }

        [Column("ZipCode", TypeName = "varchar")]

        [MaxLength(6)]
        public string ZipCode { get; set; }
            //public virtual ICollection<Student> Students { get; set; }
        }
    }


