using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ICocomoVersionServices
    {
        Task<IEnumerable<CocomoVersionReadDTO>> GetAllCocomoVersionsAsync();
        Task<CocomoVersionReadDTO> GetCocomoVersionByIdAsync(int id);
        Task<CocomoVersionReadDTO> CreateCocomoVersionAsync(CocomoVersionCreateDTO cocomoVersionDto);
        Task<bool> UpdateCocomoVersionAsync(int id, CocomoVersionUpdateDTO cocomoVersionDto);
        Task<bool> DeleteCocomoVersionAsync(int id);
    }
}
