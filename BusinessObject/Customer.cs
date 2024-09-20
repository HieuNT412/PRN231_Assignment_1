using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Customer
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        [Key]
        public string username { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string fullname { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string address { get; set; }
    }
}
