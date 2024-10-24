using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class PlatformObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Platform { get; set; }
        public string Object { get; set; }
        public string Code { get; set; }
        public string Change { get; set; }
        public string ObjectComplexity { get; set; }
        public string ChangeComplexity { get; set; }
        public string Coefficient { get; set; }
        public long Hour { get; set; }

    }
}
