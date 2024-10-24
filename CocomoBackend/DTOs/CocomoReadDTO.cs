using CocomoBackend.Models;

namespace CocomoBackend.DTOs
{
    public class CocomoReadDTO
    {

        public CocomoHeadReadDTO CocomoHead { get; set; }
        public CocomoVersionReadDTO CocomoVersion { get; set; }
        //public List<CocomoDetailReadDTO> CocomoDetails {get; set; }
        //public CocomoFactor CocomoFactor { get; set; }
        //public CocomoTypeProyect CocomoTypeProyect { get; set; }

    }
}
