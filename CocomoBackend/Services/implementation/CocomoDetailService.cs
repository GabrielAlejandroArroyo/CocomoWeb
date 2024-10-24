using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Data;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.implementation
{
    public class CocomoDetailService : ICocomoDetailService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CocomoDetailService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CocomoDetailReadDTO>> GetAllCocomoDetailAsync()
        {

            var cocomoDetail = await _context.CocomoDetails.ToListAsync();
            return _mapper.Map<IEnumerable<CocomoDetailReadDTO>>(cocomoDetail);
        }

        public async Task<CocomoDetailReadDTO> CreateCocomoDetailAsync(CocomoDetailCreateDTO cocomoDetailDto)
        {
            var cocomoDetail = _mapper.Map<CocomoDetail>(cocomoDetailDto);

            _context.CocomoDetails.Add(cocomoDetail);
            await _context.SaveChangesAsync();

            return _mapper.Map<CocomoDetailReadDTO>(cocomoDetail);
        }

        public async Task<bool> UpdateCocomoDetailAsync(int id, CocomoDetailUpdateDTO cocomoDetailDto)
        {
            if (id != cocomoDetailDto.Id)
            {
                return false;
            }

            var cocomoDetail = await _context.CocomoDetails.FindAsync(id);

            if (cocomoDetail == null)
            {
                return false;
            }

            _mapper.Map(cocomoDetailDto, cocomoDetail);

            _context.Entry(cocomoDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCocomoDetailAsync(int id)
        {
            var cocomoDetail = await _context.CocomoDetails.FindAsync(id);

            if (cocomoDetail == null)
            {
                return false;
            }

            _context.CocomoDetails.Remove(cocomoDetail);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CocomoDetailReadDTO> GetCococmoDetailByIdAsync(int id)
        {
            var cocomoDetail = await _context.CocomoDetails.FindAsync(id);

            if (cocomoDetail == null)
            {
                return null;
            }

            return _mapper.Map<CocomoDetailReadDTO>(cocomoDetail); throw new NotImplementedException();
        }
    }
}
