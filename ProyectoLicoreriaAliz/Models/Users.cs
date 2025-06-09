using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLicoreriaAliz.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(20)]
        public string dni { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        public DateTime birthdate { get; set; }


        [ForeignKey("roleId")]
        public int roleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
