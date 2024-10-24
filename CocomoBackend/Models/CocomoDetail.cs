using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//namespace Prospection.Seed.Models
namespace CocomoBackend.Models
{
    public class CocomoDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
       
        public string Description { get; set; }

        public int IdCocomoVersion { get; set; }

        public PlatformObjectTime Item { get; set; }

        //public CocomoVersion CocomoVersion { get; set; }


        // Relación de uno a muchos
        //public ICollection<CocomoVersion> CocomoVersions { get; set; }  // Navegación a CocomoDetail

    }
}