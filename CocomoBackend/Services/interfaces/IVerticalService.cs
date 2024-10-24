using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface IVerticalService
    {
        Task<IEnumerable<VerticalReadDTO>> GetAllVerticalsAsync();
        Task<VerticalReadDTO> GetVerticalByIdAsync(int id);
        Task<VerticalReadDTO> CreateVerticalAsync(VerticalCreateDTO verticalDTO);
        Task<bool> UpdateVerticalAsync(int id, VerticalUpdateDTO verticalDTO);
        Task<bool> DeleteVerticalAsync(int id);
    }
}
