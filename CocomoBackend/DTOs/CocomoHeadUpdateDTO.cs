namespace CocomoBackend.DTOs
{
    public class CocomoHeadUpdateDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdCocomostate { get; set; }
        public DateTime EstimationDate { get; set; }
        public string EstimationObservations { get; set; }
        public DateTime RevisionDate { get; set; }
        public int IdOwner { get; set; }
        public int IdRevisor { get; set; }
    }
}
