using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Data;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.implementation
{
    public class CocomoStateService : ICocomoStateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CocomoStateService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CocomoStateReadDTO>> GetAllCocomoStatesAsync()
        {
            var cocomoStates = await _context.CocomoStates.ToListAsync();
            return _mapper.Map<IEnumerable<CocomoStateReadDTO>>(cocomoStates);
        }

        public async Task<CocomoStateReadDTO> GetCocomoStateByIdAsync(int id)
        {
            var cocomoState = await _context.CocomoStates.FindAsync(id);

            if (cocomoState == null)
            {
                return null;
            }

            return _mapper.Map<CocomoStateReadDTO>(cocomoState);
        }

        public async Task<CocomoStateReadDTO> CreateCocomoStateAsync(CocomoStateCreateDTO cocomoStateDto)
        {
            var cocomoState = _mapper.Map<CocomoState>(cocomoStateDto);

            _context.CocomoStates.Add(cocomoState);
            await _context.SaveChangesAsync();

            return _mapper.Map<CocomoStateReadDTO>(cocomoState);
        }

        public async Task<bool> UpdateCocomoStateAsync(int id, CocomoStateUpdateDTO cocomoStateDto)
        {
            if (id != cocomoStateDto.Id)
            {
                return false;
            }

            var cocomoState = await _context.CocomoStates.FindAsync(id);

            if (cocomoState == null)
            {
                return false;
            }

            _mapper.Map(cocomoStateDto, cocomoState);

            _context.Entry(cocomoState).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCocomoStateAsync(int id)
        {
            var cocomoState = await _context.CocomoStates.FindAsync(id);

            if (cocomoState == null)
            {
                return false;
            }

            _context.CocomoStates.Remove(cocomoState);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
