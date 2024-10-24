using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ITypeRequerimentService
    {
        Task<IEnumerable<TypeRequirementReadDTO>> GetAllTypeRequirementsAsync();
        Task<TypeRequirementReadDTO> GetTypeRequerimentByIdAsync(int id);
        Task<TypeRequirementReadDTO> CreateTypeRequirementAsync(TypeRequirementCreateDTO typeRequirementDTO);
        Task<bool> UpdateTypeRequirementAsync(int id, TypeRequirementUpdateDTO typeRequirementDTO);
        Task<bool> DeleteTypeRequirementAsync(int id);
    }
}
