using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//namespace Prospection.Models
namespace CocomoBackend.Models
{
    public class CocomoState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CocomoHead> CocomoHeads { get; set; }
    }
}

