using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//namespace Prospection.Seed.Models
namespace CocomoBackend.Models
{
    public class CocomoHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }
        public string Description { get; set; }

        public int IdCustomer { get; set; }

        public Customer Customer { get; set; }

        public int IdTypeRequirement { get; set; }

        public TypeRequirement TypeRequirement { get; set; }

        public int IdTypeComplexity { get; set; }
        public TypeComplexity TypeComplexity { get; set; }

        public int IdCocomostate { get; set; }
        public CocomoState Cocomostate { get; set; }
        
        public DateTime EstimationDate { get; set; }
        public string EstimationObservations { get; set; }

        public int IdModule { get; set; }
        public Module Module { get; set; }

        public int IdVertical { get; set; }
        public Vertical Vertical { get; set; }

        public DateTime RevisionDate { get; set; }

        public int IdOwner { get; set; }

        public int IdRevisor { get; set; }

        public bool ActiveEstimation { get; set; }

        public bool ActiveCaim { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        // Relación de uno a muchos
        public ICollection<CocomoVersion> CocomoVersions { get; set; }  // Navegación a CocomoVersion

    }
}