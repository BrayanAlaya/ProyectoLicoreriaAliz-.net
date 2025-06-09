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

        [ForeignKey("entradaProductoId")]
        public int entradaProductoId { get; set; }
        public virtual Entradas_productos Entradas_productos { get; set; }

        [ForeignKey("product_id")]
        public int product_id { get; set; }
        public virtual Producto Producto { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;

    }
}
