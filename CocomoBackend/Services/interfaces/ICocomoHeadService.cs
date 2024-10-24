using CocomoBackend.DTOs;
using CocomoBackend.Models;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.interfaces
{
    public interface ICocomoHeadService
    {
        Task<IEnumerable<CocomoHeadReadDTO>> GetAllCocomoHeadsAsync();
        Task<CocomoHeadReadDTO> GetCocomoHeadByIdAsync(int id);
        Task<CocomoHeadReadDTO> CreateCocomoHeadAsync(CocomoHeadCreateDTO cocomoHeadDto);
        Task<bool> UpdateCocomoHeadAsync(int id, CocomoHeadUpdateDTO cocomoHeadDto);
        Task<bool> DeleteCocomoHeadAsync(int id);
        Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> GetCocomoHeadsAsync(int page, int pageSize, string? search, string? sortColumn, bool sortDescending);
        //Task<List<CocomoHead>> SearchCocomoHeadsAsync(CocomoHeadSearchDTO searchDto);
        //Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> SearchCocomoHeadsAsync(CocomoHeadSearchDTO searchDto);

        Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> GetCocomoHeadsAsync(int page, int pageSize, CocomoHeadSearchDTO cocomoHeadSearchDTO);



    }
}
