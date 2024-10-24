using CocomoBackend.DTOs;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services
{
    public interface ICocomoStateVersionService
    {
        Task<IEnumerable<CocomoStateVersionReadDTO>> GetAllCocomoStatesVersionAsync();
        Task<CocomoStateVersionReadDTO> GetCocomoStateVersionByIdAsync(int id);
        Task<CocomoStateVersionReadDTO> CreateCocomoStateVersionAsync(CocomoStateVersionCreateDTO cocomoStateVersionDto);
        Task<bool> UpdateCocomoStateVersionAsync(int id, CocomoStateVersionUpdateDTO cocomoStateVersionDto);
        Task<bool> DeleteCocomoStateVersionAsync(int id);
    }
}
