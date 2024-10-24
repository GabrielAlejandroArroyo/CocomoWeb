using CocomoBackend.DTOs;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.interfaces
{
    public interface ICocomoStateService
    {
        Task<IEnumerable<CocomoStateReadDTO>> GetAllCocomoStatesAsync();
        Task<CocomoStateReadDTO> GetCocomoStateByIdAsync(int id);
        Task<CocomoStateReadDTO> CreateCocomoStateAsync(CocomoStateCreateDTO cocomoStateDto);
        Task<bool> UpdateCocomoStateAsync(int id, CocomoStateUpdateDTO cocomoStateDto);
        Task<bool> DeleteCocomoStateAsync(int id);
    }
}
