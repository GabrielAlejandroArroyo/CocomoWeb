using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ITypeFactorDetailService
    {
        Task<IEnumerable<TypeFactorDetailReadDTO>> GetAllTypeFactorDetailsAsync();

    }
}
