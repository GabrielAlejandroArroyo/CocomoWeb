using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class TypeComplexity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdTypeRequirement { get; set; }
        public string Name { get; set; }

        public ICollection<CocomoHead> CocomoHeads { get; set; }
    }
}
