using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class TypeCorrectionFactor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FactorType { get; set; }
        public string Item { get; set; }
        public string Data { get; set; }
        public string Factor { get; set; }
        public string Observation { get; set; }

    }
}
