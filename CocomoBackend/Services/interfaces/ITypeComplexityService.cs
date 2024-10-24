using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ITypeComplexityService
    {
        Task<IEnumerable<TypeComplexityReadDTO>> GetAllTypeComplexitiesAsync();
        Task<TypeComplexityReadDTO> GetTypeComplexityByIdAsync(int id);
        Task<TypeComplexityReadDTO> CreateTypeComplexityAsync(TypeComplexityCreateDTO typeComplexityDTO);
        Task<bool> UpdateTypeComplexityAsync(int id, TypeComplexityUpdateDTO customerDTO);
        Task<bool> DeleteTypeComplexityAsync(int id);
    }
}
