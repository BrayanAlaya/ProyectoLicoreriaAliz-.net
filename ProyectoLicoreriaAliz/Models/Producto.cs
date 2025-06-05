using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal price_sell { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal price_buy { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [Required]
        public int stock { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public bool deleted { get; set; } = false;

        public DateTime created_date { get; set; } = DateTime.UtcNow;

        public bool state { get; set; }


        public ICollection<Purchase_detail> Purchase_detail { get; set; }
        public ICollection<Entradas_productos> Entradas_productos { get; set; }
        public ICollection<Provider_detalle_producto> Provider_detalle_producto { get; set; }
        public ICollection<Detalle_entrada> Detalle_Entradas { get; set; } 
    }
}
