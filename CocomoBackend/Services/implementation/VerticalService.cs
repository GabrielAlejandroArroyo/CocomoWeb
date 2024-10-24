using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class VerticalService : IVerticalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VerticalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VerticalReadDTO> CreateVerticalAsync(VerticalCreateDTO verticalDTO)
        {
            var vertical = _mapper.Map<Vertical>(verticalDTO);

            _context.Verticals.Add(vertical);
            await _context.SaveChangesAsync();

            return _mapper.Map<VerticalReadDTO>(vertical);
        }

        public async Task<bool> DeleteVerticalAsync(int id)
        {
            var vertical = await _context.Verticals.FindAsync(id);

            if (vertical == null)
            {
                return false;
            }

            _context.Verticals.Remove(vertical);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<VerticalReadDTO>> GetAllVerticalsAsync()
        {
            var verticals = await _context.Verticals.ToListAsync();
            return _mapper.Map<IEnumerable<VerticalReadDTO>>(verticals);
        }

        public async Task<VerticalReadDTO> GetVerticalByIdAsync(int id)
        {
            var vertical = await _context.Verticals.FindAsync(id);
            if (vertical == null)
            {
                return null;
            }

            return _mapper.Map<VerticalReadDTO>(vertical);
        }

        public async Task<bool> UpdateVerticalAsync(int id, VerticalUpdateDTO verticalDTO)
        {
            if (id != verticalDTO.Id)
            {
                return false;
            }

            var vertical = await _context.Verticals.FindAsync(id);

            if (vertical == null)
            {
                return false;
            }

            _mapper.Map(verticalDTO, vertical);

            _context.Entry(vertical).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
