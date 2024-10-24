using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.Data;
using CocomoBackend.Models;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;

namespace CocomoBackend.Services.implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerReadDTO>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerReadDTO>>(customers);
        }

        public async Task<CustomerReadDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerReadDTO>(customer);
        }

        public async Task<CustomerReadDTO> CreateCustomerAsync(CustomerCreateDto customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerReadDTO>(customer);
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDTO customerDTO)
        {

            if (id != customerDTO.Id)
            {
                return false;
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _mapper.Map(customerDTO, customer);

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<(IEnumerable<CocomoHeadReadDTO> cocomoHeads, int totalRecords)> GetCocomoHeadsAsync(
    int page, int pageSize, string? search, int? code, string? sortColumn, bool sortDescending)
        {
            var query = _context.CocomoHeads.AsQueryable();

            // Aplicar el filtro por Code si se proporciona
            if (code.HasValue)
            {
                query = query.Where(ch => ch.Code == code.Value);
            }

            // Aplicar búsqueda por Title o Description si se proporciona un término de búsqueda
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(ch =>
                    ch.Code.Equals(search) ||
                    ch.Description.Contains(search));
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
                    Description = ch.Description
                })
                .ToListAsync();

            return (cocomoHeads, totalRecords);
        }

    }
}
