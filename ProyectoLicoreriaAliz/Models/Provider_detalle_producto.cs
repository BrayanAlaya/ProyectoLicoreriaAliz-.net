using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Provider_detalle_producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("provider_id")]
        public Provider Provider { get; set; }

        [ForeignKey("producto_id")]
        public Producto Producto { get; set; }
    }
}
