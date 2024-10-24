using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Data;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.implementation
{
    public class CocomoVersionService : ICocomoVersionServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CocomoVersionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CocomoVersionReadDTO>> GetAllCocomoVersionsAsync()
        {

            var cocomoVersion = await _context.CocomoVersions.ToListAsync();
            return _mapper.Map<IEnumerable<CocomoVersionReadDTO>>(cocomoVersion);
        }

        public async Task<CocomoVersionReadDTO> GetCocomoVersionByIdAsync(int id)
        {
            var cocomoVersion = await _context.CocomoVersions.FindAsync(id);

            if (cocomoVersion == null)
            {
                return null;
            }

            return _mapper.Map<CocomoVersionReadDTO>(cocomoVersion);
        }

        public async Task<CocomoVersionReadDTO> CreateCocomoVersionAsync(CocomoVersionCreateDTO cocomoVersionDto)
        {
            var cocomoVersion = _mapper.Map<CocomoVersion>(cocomoVersionDto);

            _context.CocomoVersions.Add(cocomoVersion);
            await _context.SaveChangesAsync();

            return _mapper.Map<CocomoVersionReadDTO>(cocomoVersion);
        }

        public async Task<bool> UpdateCocomoVersionAsync(int id, CocomoVersionUpdateDTO cocomoVersionDto)
        {
            if (id != cocomoVersionDto.Id)
            {
                return false;
            }

            var cocomoVersion = await _context.CocomoVersions.FindAsync(id);

            if (cocomoVersion == null)
            {
                return false;
            }

            _mapper.Map(cocomoVersionDto, cocomoVersion);

            _context.Entry(cocomoVersion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCocomoVersionAsync(int id)
        {
            var cocomoVersion = await _context.CocomoVersions.FindAsync(id);

            if (cocomoVersion == null)
            {
                return false;
            }

            _context.CocomoVersions.Remove(cocomoVersion);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
