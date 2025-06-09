using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string dni { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal monto { get; set; }
        [Required]
        public DateTime date { get; set; } = DateTime.UtcNow;

        [ForeignKey("clientId")]
        public int clientId { get; set; }
        public virtual Clients Clients { get; set; }


        [ForeignKey("refundId")]
        public int refundId { get; set; }
        public virtual Refund? Refund { get; set; }

        public ICollection<Purchase_detail> Purchase_details { get; set; } 
    }
}
