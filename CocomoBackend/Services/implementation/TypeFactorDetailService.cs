using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class TypeFactorDetailService : ITypeFactorDetailService

    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TypeFactorDetailService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TypeFactorDetailReadDTO>> GetAllTypeFactorDetailsAsync()
        {
            var typeFactorDetail = await _context.TypeFactorDetails.ToListAsync();
            return _mapper.Map<IEnumerable<TypeFactorDetailReadDTO>>(typeFactorDetail);
        }
    }
}
