using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class ModuleService : IModuleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ModuleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ModuleReadDTO> CreateModuleAsync(ModuleCreateDTO moduleDTO)
        {
            var module = _mapper.Map<Customer>(moduleDTO);

            _context.Customers.Add(module);
            await _context.SaveChangesAsync();

            return _mapper.Map<ModuleReadDTO>(module);
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return false;
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ModuleReadDTO>> GetAllModulesAsync()
        {
            var modules = await _context.Modules.ToListAsync();
            return _mapper.Map<IEnumerable<ModuleReadDTO>>(modules);
        }

        public async Task<ModuleReadDTO> GetModuleByIdAsync(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return null;
            }

            return _mapper.Map<ModuleReadDTO>(module);

        }

        public async Task<bool> UpdateModuleAsync(int id, ModuleUpdateDTO moduleDTO)
        {

            if (id != moduleDTO.Id)
            {
                return false;
            }

            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return false;
            }

            _mapper.Map(moduleDTO, module);

            _context.Entry(module).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
