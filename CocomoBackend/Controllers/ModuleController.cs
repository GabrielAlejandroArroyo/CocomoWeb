using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {

        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleReadDTO>>> GetModule()
        {
            var modules = await _moduleService.GetAllModulesAsync();
            return Ok(modules);
        }

    }
}
