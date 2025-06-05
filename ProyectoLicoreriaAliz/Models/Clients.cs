using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLicoreriaAliz.Models
{
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        [StringLength(50)]
        public string type_document { get; set; }

        [StringLength(30)]
        public string nmr_document { get; set; }

        [StringLength(250)]
        public string? address { get; set; }


        public ICollection<Purchase> Purchase { get; set; } 

    }
}
