using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class TypeComplexityService : ITypeComplexityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TypeComplexityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<TypeComplexityReadDTO> CreateTypeComplexityAsync(TypeComplexityCreateDTO typeComplexityDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTypeComplexityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeComplexityReadDTO>> GetAllTypeComplexitiesAsync()
        {
            var typeComplexities = await _context.TypeComplexities.ToListAsync();
            return _mapper.Map<IEnumerable<TypeComplexityReadDTO>>(typeComplexities);
        }

        public Task<TypeComplexityReadDTO> GetTypeComplexityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTypeComplexityAsync(int id, TypeComplexityUpdateDTO customerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
