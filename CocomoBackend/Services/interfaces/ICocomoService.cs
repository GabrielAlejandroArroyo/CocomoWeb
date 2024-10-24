using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ICocomoService
    {
        //Task<IEnumerable<CocomoDetailReadDTO>> GetAllCocomoDetailAsync();
        Task<CocomoReadDTO> GetCococmoByIdAsync(int idhead, int idversion);
        Task<CocomoReadDTO> CreateCocomoAsync(CocomoHeadCreateDTO cocomoHeadlDTO);
        Task<CocomoReadDTO> NewVersionCocomoAsync(int idhead, int idversion);

        //Task<bool> UpdateCocomoDetailAsync(int id, CocomoDetailUpdateDTO cocomoDetailDTO);
        //Task<bool> DeleteCocomoDetailAsync(int id);
    }
}
