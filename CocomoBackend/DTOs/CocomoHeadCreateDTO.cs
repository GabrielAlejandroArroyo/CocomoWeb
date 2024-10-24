using CocomoBackend.Models;

namespace CocomoBackend.DTOs
{
    public class CocomoHeadCreateDTO
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int IdCustomer { get; set; }
        public int IdTypeRequirement { get; set; }
        public int IdTypeComplexity { get; set; }
        public int IdCocomostate { get; set; }
        public int IdModule { get; set; }
        public int IdVertical { get; set; }
        public DateTime EstimationDate { get; set; }
        public string EstimationObservations { get; set; }
        public DateTime RevisionDate { get; set; }
        public int IdOwner { get; set; }
        public int IdRevisor { get; set; }
        public bool ActiveEstimation { get; set; }
        public bool ActiveCaim { get; set; }
    }
}
