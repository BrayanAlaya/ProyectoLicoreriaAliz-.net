using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLicoreriaAliz.Models
{
    public class Entradas_productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("provider_id")]
        public Provider Provider { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;


        public ICollection<Detalle_entrada> Detalle_entradas { get; set; }

    }
}
