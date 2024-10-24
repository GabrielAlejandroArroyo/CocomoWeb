using CocomoBackend.Models;

namespace CocomoBackend.DTOs
{
    public class TypeFactorReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TypeFactorDetail> FactorDetails { get; set; }
    }
}
