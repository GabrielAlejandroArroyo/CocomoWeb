using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ITypeFactorService
    {
        Task<IEnumerable<TypeFactorReadDTO>> GetAllTypeFactorsAsync();
    }
}
