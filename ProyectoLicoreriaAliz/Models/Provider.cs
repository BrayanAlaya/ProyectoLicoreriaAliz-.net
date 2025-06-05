using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(250)]
        public string name { get; set; }
        [Required]
        [StringLength(9)]
        public string phone { get; set; }
        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;

        public ICollection<Entradas_productos> Entradas_productos { get; set; } 
        public ICollection<Provider_detalle_producto> Provider_detalle_producto { get; set; }

    }
}
