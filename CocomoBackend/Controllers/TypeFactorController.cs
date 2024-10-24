using CocomoBackend.DTOs;
using CocomoBackend.Services.implementation;
using CocomoBackend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFactorController : ControllerBase
    {
        private readonly ITypeFactorService _typeFactorService;

        public TypeFactorController(ITypeFactorService typeFactorService)
        {
            _typeFactorService = typeFactorService;
        }

        // GET: api/TypeFactor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDTO>>> GetTypeFactors()
        {
            var typeFactors = await _typeFactorService.GetAllTypeFactorsAsync();
            return Ok(typeFactors);
        }



    }
}
