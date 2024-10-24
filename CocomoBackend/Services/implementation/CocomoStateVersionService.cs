using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Data;
using CocomoBackend.Models;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.implementation
{
    public class CocomoStateVersionService : ICocomoStateVersionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CocomoStateVersionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CocomoStateVersionReadDTO>> GetAllCocomoStatesVersionAsync()
        {

            var cocomoStatesVersion = await _context.CocomoStatesVersions.ToListAsync();
            return _mapper.Map<IEnumerable<CocomoStateVersionReadDTO>>(cocomoStatesVersion);
        }

        public async Task<CocomoStateVersionReadDTO> GetCocomoStateVersionByIdAsync(int id)
        {
            var cocomoStateVersion = await _context.CocomoStatesVersions.FindAsync(id);

            if (cocomoStateVersion == null)
            {
                return null;
            }

            return _mapper.Map<CocomoStateVersionReadDTO>(cocomoStateVersion);
        }

        public async Task<CocomoStateVersionReadDTO> CreateCocomoStateVersionAsync(CocomoStateVersionCreateDTO cocomoStateVersionDto)
        {
            var cocomoStateVersion = _mapper.Map<CocomoStateVersion>(cocomoStateVersionDto);

            _context.CocomoStatesVersions.Add(cocomoStateVersion);
            await _context.SaveChangesAsync();

            return _mapper.Map<CocomoStateVersionReadDTO>(cocomoStateVersion);
        }

        public async Task<bool> UpdateCocomoStateVersionAsync(int id, CocomoStateVersionUpdateDTO cocomoStateVersionDto)
        {
            if (id != cocomoStateVersionDto.Id)
            {
                return false;
            }

            var cocomoStateVersion = await _context.CocomoStatesVersions.FindAsync(id);

            if (cocomoStateVersion == null)
            {
                return false;
            }

            _mapper.Map(cocomoStateVersionDto, cocomoStateVersion);

            _context.Entry(cocomoStateVersion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCocomoStateVersionAsync(int id)
        {
            var cocomoStateVersion = await _context.CocomoStatesVersions.FindAsync(id);

            if (cocomoStateVersion == null)
            {
                return false;
            }

            _context.CocomoStatesVersions.Remove(cocomoStateVersion);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
