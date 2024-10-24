using CocomoBackend.DTOs;

namespace CocomoBackend.Services.interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerReadDTO>> GetAllCustomersAsync();
        Task<CustomerReadDTO> GetCustomerByIdAsync(int id);
        Task<CustomerReadDTO> CreateCustomerAsync(CustomerCreateDto customerDTO);
        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDTO customerDTO);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
