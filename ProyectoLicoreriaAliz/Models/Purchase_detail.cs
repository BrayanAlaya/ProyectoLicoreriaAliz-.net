using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Purchase_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        [ForeignKey("purchaseId")]
        public int purchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }


        [ForeignKey("productId")]
        public int productId { get; set; }
        public virtual Producto Producto { get; set; }


        [Required]
        public int cantidad { get; set; }
        [StringLength(500)]
        public string description { get; set; }
    }
}
