using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ITypeProyectService
    {
        Task<IEnumerable<TypeProyectReadDTO>> GetAllTypeProyectsAsync();
        Task<TypeProyectReadDTO> GetTypeProyectByIdAsync(int id);
        Task<TypeProyectReadDTO> CreateTypeProyectAsync(TypeProyectCreateDTO typeProyectDTO);
        Task<bool> UpdateTypeProyectAsync(int id, TypeProyectUpdateDTO typeProyectDTO);
        Task<bool> DeleteTypeProyectAsync(int id);
    }
}
