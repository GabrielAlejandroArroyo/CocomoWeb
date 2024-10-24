using CocomoBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CocomoBackend.DTOs
{
    public class CocomoVersionReadDTO
    {
        public int Id { get; set; }

        public int IdCocomoHead { get; set; }

        public string Version { get; set; }

        public int IdCocomoStateVersion { get; set; }
    }
}
