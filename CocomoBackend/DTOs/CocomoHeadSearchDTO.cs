namespace CocomoBackend.DTOs
{
    public class CocomoHeadSearchDTO
    {
        public int? Code { get; set; }
        public string? Description { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdTypeRequirement { get; set; }
        public int? IdTypeComplexity { get; set; }
        public int? IdCocomostate { get; set; }
        public int? IdModule { get; set; }
        public int? IdVertical { get; set; }
        public DateTime? EstimationDate { get; set; }
        public string? EstimationObservations { get; set; }
        public DateTime? RevisionDate { get; set; }
        public int? IdOwner { get; set; }
        public int? IdRevisor { get; set; }
        public bool? ActiveEstimation { get; set; }
        public bool? ActiveCaim { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        //public int Page { get; set; } = 1;
        //public int PageSize { get; set; } = 10;
        public string? SortColumn { get; set; }
        public bool? SortDescending { get; set; } = false;
    }
}
