using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services
{
    public class PlatformObjectTimeService : IPlatformObjectTimeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PlatformObjectTimeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformObjectTimeReadDTO>> GetAllPlatformObjectTimesAsync()
        {
            var platformObjectTimes = await _context.PlatformObjectTimes.ToListAsync();
            return _mapper.Map<IEnumerable<PlatformObjectTimeReadDTO>>(platformObjectTimes);
        }

        public async Task<PlatformObjectTimeReadDTO> GetPlatformObjectTimeByIdAsync(int id)
        {
            var platformObjectTime = await _context.PlatformObjectTimes.FindAsync(id);

            if (platformObjectTime == null)
            {
                return null;
            }

            return _mapper.Map<PlatformObjectTimeReadDTO>(platformObjectTime);
        }

        public async Task<PlatformObjectTimeReadDTO> CreatePlatformObjectTimeAsync(PlatformObjectTimeCreateDTO platformObjectTimeDTO)
        {
                var platformObjectTime = _mapper.Map<PlatformObjectTime>(platformObjectTimeDTO);

                _context.PlatformObjectTimes.Add(platformObjectTime);
                await _context.SaveChangesAsync();

                return _mapper.Map<PlatformObjectTimeReadDTO>(platformObjectTime);
        }


        public async Task<bool> UpdatePlatformObjectTimeAsync(int id, PlatformObjectTimeUpdateDTO platformObjectTimeDTO)
        {
            if (id != platformObjectTimeDTO.Id)
            {
                return false;
            }

            var platformObjectTime = await _context.PlatformObjectTimes.FindAsync(id);

            if (platformObjectTime == null)
            {
                return false;
            }

            _mapper.Map(platformObjectTimeDTO, platformObjectTime);

            _context.Entry(platformObjectTime).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeletePlatformObjectTimeAsync(int id)
        {
                var platformObjectTime = await _context.PlatformObjectTimes.FindAsync(id);

                if (platformObjectTime == null)
                {
                    return false;
                }

                _context.PlatformObjectTimes.Remove(platformObjectTime);
                await _context.SaveChangesAsync();

                return true;
        }
    }
}
