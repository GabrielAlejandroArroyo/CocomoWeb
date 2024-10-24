namespace CocomoBackend.DTOs
{
    public class CocomoSearchDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }
        public int? Code { get; set; }
        public string? SortColumn { get; set; }
        public bool SortDescending { get; set; } = false;
    }
}
