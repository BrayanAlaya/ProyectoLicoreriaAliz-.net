using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Provider_detalle_producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("providerId")]
        public int providerId { get; set; }
        public virtual Provider Provider { get; set; }


        [ForeignKey("productoId")]
        public int productoId { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
