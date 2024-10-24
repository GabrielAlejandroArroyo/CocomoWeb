using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class TypeRequerimentService : ITypeRequerimentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TypeRequerimentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<TypeRequirementReadDTO> CreateTypeRequirementAsync(TypeRequirementCreateDTO typeRequirementDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTypeRequirementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeRequirementReadDTO>> GetAllTypeRequirementsAsync()
        {
            var typeRequirements = await _context.TypeRequirements.ToListAsync();
            return _mapper.Map<IEnumerable<TypeRequirementReadDTO>>(typeRequirements);

        }

        public Task<TypeRequirementReadDTO> GetTypeRequerimentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTypeRequirementAsync(int id, TypeRequirementUpdateDTO typeRequirementDTO)
        {
            throw new NotImplementedException();
        }
    }
}
