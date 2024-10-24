using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocomoBackend.Models
{
    public class CocomoFactor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCocomoVersion { get; set; }

        public TypeFactor TypeFactor { get; set; }

        //public CocomoVersion CocomoVersions { get; set; }

    }
}
