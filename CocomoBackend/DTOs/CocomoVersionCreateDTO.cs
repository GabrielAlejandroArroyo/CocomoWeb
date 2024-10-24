using CocomoBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.DTOs
{
    public class CocomoVersionCreateDTO
    {
        public int IdCocomoHead { get; set; }

        public string Version { get; set; }

        public int IdCocomoStateVersion { get; set; }
    }
}
