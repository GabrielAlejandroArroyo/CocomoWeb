using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleReadDTO>> GetAllModulesAsync();
        Task<ModuleReadDTO> GetModuleByIdAsync(int id);
        Task<ModuleReadDTO> CreateModuleAsync(ModuleCreateDTO moduleDTO);
        Task<bool> UpdateModuleAsync(int id, ModuleUpdateDTO moduleDTO);
        Task<bool> DeleteModuleAsync(int id);
    }
}
