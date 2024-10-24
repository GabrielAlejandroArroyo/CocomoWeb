using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VerticalController : ControllerBase
    {
        private readonly IVerticalService _verticalService;

        public VerticalController(IVerticalService verticalService)
        {
        _verticalService = verticalService;
        }

        // GET: api/Vertical
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerticalReadDTO>>> GetVertical()
        {
            var verticals = await _verticalService.GetAllVerticalsAsync();
            return Ok(verticals);
        }

    }

}
