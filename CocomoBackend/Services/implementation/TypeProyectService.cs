using AutoMapper;
using CocomoBackend.Data;
using CocomoBackend.DTOs;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Services.implementation
{
    public class TypeProyectService : ITypeProyectService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TypeProyectService (AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TypeProyectReadDTO>> GetAllTypeProyectsAsync()
        {
            var typeProyects = await _context.TypeProyects.ToListAsync();
            return _mapper.Map<IEnumerable<TypeProyectReadDTO>>(typeProyects);
        }

        public async Task<TypeProyectReadDTO> GetTypeProyectByIdAsync(int id)
        {
            var typeProyect = await _context.TypeProyects.FindAsync(id);

            if (typeProyect == null)
            {
                return null;
            }

            return _mapper.Map<TypeProyectReadDTO>(typeProyect);
        }


        public async Task<TypeProyectReadDTO> CreateTypeProyectAsync(TypeProyectCreateDTO typeProyectDTO)
        {
            var typeProyect = _mapper.Map<TypeProyect>(typeProyectDTO);

            _context.TypeProyects.Add(typeProyect);
            await _context.SaveChangesAsync();

            return _mapper.Map<TypeProyectReadDTO>(typeProyect);
        }

        public async Task<bool> UpdateTypeProyectAsync(int id, TypeProyectUpdateDTO typeProyectDTO)
        {
            if (id != typeProyectDTO.Id)
            {
                return false;
            }

            var typeProyect = await _context.TypeProyects.FindAsync(id);

            if (typeProyect == null)
            {
                return false;
            }

            _mapper.Map(typeProyectDTO, typeProyect);

            _context.Entry(typeProyect).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTypeProyectAsync(int id)
        {
            var typeProyect = await _context.TypeProyects.FindAsync(id);

            if (typeProyect == null)
            {
                return false;
            }

            _context.TypeProyects.Remove(typeProyect);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
