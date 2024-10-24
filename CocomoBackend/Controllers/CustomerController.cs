using Microsoft.AspNetCore.Mvc;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDTO>>> GetCustomer()
        {
            var customer = await _customerService.GetAllCustomersAsync();
            return Ok(customer);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDTO>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<CustomerReadDTO>> CreateCustomer(CustomerCreateDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest();
            }

            var newCustomerState = await _customerService.CreateCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomerState.Id }, newCustomerState);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDTO customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            var result = await _customerService.UpdateCustomerAsync(id, customerDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
