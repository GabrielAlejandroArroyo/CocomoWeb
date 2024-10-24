using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class TypeFactorDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdTypeFactor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Data { get; set; }
        public string Formula { get; set; }
        public string Observation { get; set; }

    }
}
