using CocomoBackend.DTOs;

namespace CocomoBackend.Services
{
    public interface IPlatformObjectTimeService
    {
        Task<IEnumerable<PlatformObjectTimeReadDTO>> GetAllPlatformObjectTimesAsync();
        Task<PlatformObjectTimeReadDTO> GetPlatformObjectTimeByIdAsync(int id);
        Task<PlatformObjectTimeReadDTO> CreatePlatformObjectTimeAsync(PlatformObjectTimeCreateDTO platformObjectTimeDTO);
        Task<bool> UpdatePlatformObjectTimeAsync(int id, PlatformObjectTimeUpdateDTO platformObjectTimeDTO);
        Task<bool> DeletePlatformObjectTimeAsync(int id);
    }
}
