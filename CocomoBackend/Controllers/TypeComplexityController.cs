using CocomoBackend.Data;
using Prospection.Models;
using CocomoBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypeComplexityController : ControllerBase
    {
        private readonly ITypeComplexityService _typeComplexityService;
        public TypeComplexityController(ITypeComplexityService typeComplexityService)
        {
            _typeComplexityService = typeComplexityService;
        }

        // GET: api/TypeComplexity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeComplexityReadDTO>>> GetTypeComplexities()
        {
            var typeComplexities = await _typeComplexityService.GetAllTypeComplexitiesAsync();
            return Ok(typeComplexities);
        }

    }
}
