using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ICocomoDetailService
    {
        Task<IEnumerable<CocomoDetailReadDTO>> GetAllCocomoDetailAsync();
        Task<CocomoDetailReadDTO> GetCococmoDetailByIdAsync(int id);
        Task<CocomoDetailReadDTO> CreateCocomoDetailAsync(CocomoDetailCreateDTO cocomoDetailDTO);
        Task<bool> UpdateCocomoDetailAsync(int id, CocomoDetailUpdateDTO cocomoDetailDTO);
        Task<bool> DeleteCocomoDetailAsync(int id);

    }
}
