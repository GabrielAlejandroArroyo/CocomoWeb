using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


//namespace cocomobackend.Models
//namespace Prospection.Models
namespace CocomoBackend.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CocomoHead> CocomoHeads { get; set; }
    }
}
