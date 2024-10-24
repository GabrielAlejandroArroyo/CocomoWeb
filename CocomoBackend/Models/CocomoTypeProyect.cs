using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.Models
{
    public class CocomoTypeProyect
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCocomoVersion { get; set; }

        public int IdTypeProyect { get; set; }
        public string ProyectType { get; set; }
        public string Description { get; set; }
        public int AD { get; set; }
        public int DD { get; set; }
        public int PP { get; set; }
        public int SDT { get; set; }
        public int CP { get; set; }
        public int DT { get; set; }
        public int DF { get; set; }
        public int DB { get; set; }
        public int Total { get; set; }
        //public bool Editable { get; set; }
        
    }
}
