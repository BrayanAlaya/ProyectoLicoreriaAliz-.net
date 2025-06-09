using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLicoreriaAliz.Models
{
    public class Entradas_productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("providerId")]
        public int providerId { get; set; }
        public virtual Provider Provider { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;


        public ICollection<Detalle_entrada> Detalle_entradas { get; set; }

    }
}
