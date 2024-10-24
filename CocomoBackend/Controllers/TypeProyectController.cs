using CocomoBackend.DTOs;
using CocomoBackend.Services.implementation;
using CocomoBackend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProyectController : ControllerBase
    {
        private readonly ITypeProyectService _typeProyectService;
        public TypeProyectController(ITypeProyectService typeProyectService)
        {
            _typeProyectService = typeProyectService;
        }

        // GET: api/TypeProyect
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProyectReadDTO>>> GetTypeProyects()
        {
            var typeProyects = await _typeProyectService.GetAllTypeProyectsAsync();
            return Ok(typeProyects);
        }

    }
}
