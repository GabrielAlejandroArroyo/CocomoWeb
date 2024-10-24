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

    public class TypeRequirementController : Controller
    {
        private readonly ITypeRequerimentService _typeRequerimentService;
        public TypeRequirementController(ITypeRequerimentService typeRequerimentService)
        {
            _typeRequerimentService = typeRequerimentService;
        }

        // GET: api/TypeRequirement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeRequirementReadDTO>>> GetTypeRequirement()
        {
            var typeComplexities = await _typeRequerimentService.GetAllTypeRequirementsAsync();
            return Ok(typeComplexities);
        }
    }
}
