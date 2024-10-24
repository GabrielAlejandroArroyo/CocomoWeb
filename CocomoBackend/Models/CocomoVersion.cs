using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class CocomoVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCocomoHead { get; set; }

        [ForeignKey("IdCocomoHead")]
        public CocomoHead CocomoHead { get; set; }  // Navegación a CocomoHead
        public string Version { get; set; }
        public int IdCocomostateversion { get; set; }
        public CocomoStateVersion Cocomostateversion { get; set; }
        //public int IdCocomoDetail { get; set; }
        //public CocomoDetail CocomoDetail { get; set; }

        public int IdCocomoRequeriment { get; set; }
        //public CocomoRequeriment CocomoRequeriment { get; set; }

        public int IdCocomoFactor { get; set; }
        //public CocomoFactor CocomoFactor { get; set; }


    }
}
