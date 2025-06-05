using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Refund
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string reason { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;

        public ICollection<Purchase> Purchases { get; set; }
    }
}
