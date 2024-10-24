using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class TypeFactorService : ITypeFactorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public TypeFactorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TypeFactorReadDTO>> GetAllTypeFactorsAsync()
        {
            var typeFactor = await _context.TypeFactors.ToListAsync();

            //var typeFactorDetails = await _context.TypeFactorDetails.ToListAsync();



            return _mapper.Map<IEnumerable<TypeFactorReadDTO>>(typeFactor);
        }
    }
}
