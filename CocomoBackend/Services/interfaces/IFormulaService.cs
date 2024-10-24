using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface IFormulaService
    {
        Task<IEnumerable<FormulaReadDTO>> GetAllFormulasAsync();
        Task<FormulaReadDTO> GetFormulaByIdAsync(int id);
        Task<FormulaReadDTO> CreateFormulaAsync(FormulaCreateDto formulaDTO);
        Task<bool> UpdateFormulaAsync(int id, FormulaUpdateDTO formulaDTO);
        Task<bool> DeleteFormulaAsync(int id);
    }
}
