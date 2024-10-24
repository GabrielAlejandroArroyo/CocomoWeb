using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Data;
using CocomoBackend.Models;
using CocomoBackend.Services.interfaces;

//namespace Prospection.Seed.Services
namespace CocomoBackend.Services.implementation
{
    public class CocomoHeadService : ICocomoHeadService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CocomoHeadService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CocomoHeadReadDTO>> GetAllCocomoHeadsAsync()
        {
            var cocomoHeads = await _context.CocomoHeads.ToListAsync();
            return _mapper.Map<IEnumerable<CocomoHeadReadDTO>>(cocomoHeads);
        }

        public async Task<CocomoHeadReadDTO> GetCocomoHeadByIdAsync(int id)
        {
            var cocomoHead = await _context.CocomoHeads.FindAsync(id);

            if (cocomoHead == null)
            {
                return null;
            }

            return _mapper.Map<CocomoHeadReadDTO>(cocomoHead);
        }

        public async Task<CocomoHeadReadDTO> CreateCocomoHeadAsync(CocomoHeadCreateDTO cocomoHeadDto)
        {
            await validateCreateDTO(cocomoHeadDto);

            var cocomoHead = _mapper.Map<CocomoHead>(cocomoHeadDto);

            _context.CocomoHeads.Add(cocomoHead);
            await _context.SaveChangesAsync();

            return _mapper.Map<CocomoHeadReadDTO>(cocomoHead);
        }

        private async Task validateCreateDTO(CocomoHeadCreateDTO cocomoHeadDto)
        {
            var customerExists = await _context.Customers.AnyAsync(c => c.Id == cocomoHeadDto.IdCustomer);

            if (!customerExists)
            {
                throw new Exception("El Cliente con el Id especificado no existe.");
            }

            var typeComplexityExists = await _context.TypeComplexities.AnyAsync(c => c.Id == cocomoHeadDto.IdTypeComplexity);

            if (!typeComplexityExists)
            {
                throw new Exception("El Tipo de complejidad con el Id especificado no existe.");
            }

            var typeRequirementExists = await _context.TypeRequirements.AnyAsync(c => c.Id == cocomoHeadDto.IdTypeRequirement);

            if (!typeRequirementExists)
            {
                throw new Exception("El Tipo de requerimiento con el Id especificado no existe.");
            }

            var moduleExists = await _context.Modules.AnyAsync(c => c.Id == cocomoHeadDto.IdModule);

            if (!moduleExists)
            {
                throw new Exception("El modulo con el Id especificado no existe.");
            }

            var VerticalExists = await _context.Verticals.AnyAsync(c => c.Id == cocomoHeadDto.IdVertical);

            if (!VerticalExists)
            {
                throw new Exception("La vertical con el Id especificado no existe.");
            }

        }

        public async Task<bool> UpdateCocomoHeadAsync(int id, CocomoHeadUpdateDTO cocomoHeadDto)
        {
            if (id != cocomoHeadDto.Id)
            {
                return false;
            }

            var cocomoHead = await _context.CocomoHeads.FindAsync(id);

            if (cocomoHead == null)
            {
                return false;
            }

            _mapper.Map(cocomoHeadDto, cocomoHead);

            _context.Entry(cocomoHead).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCocomoHeadAsync(int id)
        {
            var cocomoHead = await _context.CocomoHeads.FindAsync(id);

            if (cocomoHead == null)
            {
                return false;
            }

            _context.CocomoHeads.Remove(cocomoHead);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> GetCocomoHeadsAsync(
    int page, int pageSize, string? search, string? sortColumn, bool sortDescending)
        {
            var query = _context.CocomoHeads.AsQueryable();

            // Aplicar búsqueda si se proporciona un término de búsqueda
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(ch =>
                    //ch.Code.Contains(search) ||
                    ch.Code.Equals(search) ||
                    ch.Description.Contains(search)); // Añadir más atributos si es necesario
            }

            // Ordenar según el atributo especificado
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = sortDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, sortColumn))
                    : query.OrderBy(e => EF.Property<object>(e, sortColumn));
            }

            // Obtener el número total de registros antes de la paginación
            var totalRecords = await query.CountAsync();

            // Aplicar paginación
            var cocomoHeads = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ch => new CocomoHeadReadDTO
                {
                    Id = ch.Id,
                    Code = ch.Code,
                    Description = ch.Description,
                    IdCustomer = ch.IdCustomer,
                    IdTypeRequirement = ch.IdTypeRequirement,
                    IdTypeComplexity = ch.IdTypeComplexity,
                    IdCocomostate = ch.IdCocomostate,
                    EstimationDate = ch.EstimationDate,
                    EstimationObservations = ch.EstimationObservations,
                    IdModule = ch.IdModule,
                    IdVertical = ch.IdVertical,
                    RevisionDate = ch.RevisionDate,
                    IdOwner = ch.IdOwner,
                    IdRevisor = ch.IdRevisor,
                    CreationDate = ch.CreationDate,
                    ModificationDate = ch.ModificationDate
                })
                .ToListAsync();

            return (cocomoHeads, totalRecords);
        }


        //public async Task<List<CocomoHead>> SearchCocomoHeadsAsync(CocomoHeadSearchDTO searchDto)
        //{
        //    var query = _context.CocomoHeads.AsQueryable();

        //    if (searchDto.Code.HasValue)
        //    {
        //        query = query.Where(c => c.Code == searchDto.Code.Value);
        //    }

        //    // Filtrar por nombre si se ha proporcionado
        //    if (!string.IsNullOrEmpty(searchDto.Description))
        //    {
        //        query = query.Where(c => c.Description.Contains(searchDto.Description));
        //    }

        //    // Filtrar por fecha de creación si se ha proporcionado
        //    if (searchDto.CreationDate.HasValue)
        //    {
        //        query = query.Where(c => c.CreationDate >= searchDto.CreationDate.Value);
        //    }

        //    // Filtrar por estado si se ha proporcionado
        //    if (searchDto.IdCocomostate.HasValue)
        //    {
        //        query = query.Where(c => c.IdCocomostate == searchDto.IdCocomostate.Value);
        //    }

        //    // Paginación
        //    var pagedResult = await query
        //        .Skip((searchDto.Page - 1) * searchDto.PageSize)
        //        .Take(searchDto.PageSize)
        //        .ToListAsync();

        //    return pagedResult;
        //}

        public async Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> GetCocomoHeadsAsync(int page, int pageSize, CocomoHeadSearchDTO cocomoHeadSearchDTO)
        {
            var query = _context.CocomoHeads.AsQueryable();

            if (cocomoHeadSearchDTO.Code.HasValue)
            {
                query = query.Where(c => c.Code == cocomoHeadSearchDTO.Code.Value);
            }

            // Filtrar por nombre si se ha proporcionado
            if (!string.IsNullOrEmpty(cocomoHeadSearchDTO.Description))
            {
                query = query.Where(c => c.Description.Contains(cocomoHeadSearchDTO.Description));
            }

            // Filtrar por fecha de creación si se ha proporcionado
            if (cocomoHeadSearchDTO.CreationDate.HasValue)
            {
                query = query.Where(c => c.CreationDate >= cocomoHeadSearchDTO.CreationDate.Value);
            }

            // Filtrar por estado si se ha proporcionado
            if (cocomoHeadSearchDTO.IdCocomostate.HasValue)
            {
                query = query.Where(c => c.IdCocomostate == cocomoHeadSearchDTO.IdCocomostate.Value);
            }

            // Obtener el número total de registros antes de la paginación
            var totalRecords = await query.CountAsync();

            // Aplicar paginación
            var cocomoHeads = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(ch => new CocomoHeadReadDTO
                {
                    Id = ch.Id,
                    Code = ch.Code,
                    Description = ch.Description,
                    IdCustomer = ch.IdCustomer,
                    IdTypeRequirement = ch.IdTypeRequirement,
                    IdTypeComplexity = ch.IdTypeComplexity,
                    IdCocomostate = ch.IdCocomostate,
                    EstimationDate = ch.EstimationDate,
                    EstimationObservations = ch.EstimationObservations,
                    IdModule = ch.IdModule,
                    IdVertical = ch.IdVertical,
                    RevisionDate = ch.RevisionDate,
                    IdOwner = ch.IdOwner,
                    IdRevisor = ch.IdRevisor,
                    CreationDate = ch.CreationDate,
                    ModificationDate = ch.ModificationDate
                })
                .ToListAsync();

            return (cocomoHeads, totalRecords);
        }
    }
}
