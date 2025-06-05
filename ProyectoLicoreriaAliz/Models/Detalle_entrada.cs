using Azure.Core.Pipeline;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Detalle_entrada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("entrada_producto_id")]
        public Entradas_productos Entradas_productos { get; set; }

        [Required]
        [ForeignKey("product_id")]
        public Producto Producto { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;

    }
}
