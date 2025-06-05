using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Purchase_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [ForeignKey("purchase_id")]
        public Purchase Purchase { get; set; }
        [Required]
        [ForeignKey("product_id")]
        public Producto Producto { get; set; }
        [Required]
        public int cantidad { get; set; }
        [StringLength(500)]
        public string description { get; set; }
    }
}
