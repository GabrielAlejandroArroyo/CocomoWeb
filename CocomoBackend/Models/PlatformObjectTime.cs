using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class PlatformObjectTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code  { get; set; }

        public string PlatformInitial { get; set; }

        public string PlatformDescription { get; set; }

        public string ObjectInitial { get; set; }

        public string ObjectDecription { get; set; }

        public string ChangeInitial { get; set; }

        public string ChangeDecription { get; set; }

        public string ComplexityObjectInitial { get; set; }

        public string ComplexityObjectDecription { get; set; }

        public string ComplexityChangeInitial { get; set; }

        public string ComplexityChangeDecription { get; set; }

        public float Time { get; set; }


    }
}
