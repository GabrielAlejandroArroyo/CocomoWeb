using Microsoft.AspNetCore.Mvc;
using CocomoBackend.DTOs;
using CocomoBackend.Services;


namespace CocomoBackend.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CocomoStateVersionController : ControllerBase
    {
        private readonly ICocomoStateVersionService _cocomoStateVersionService;

        public CocomoStateVersionController(ICocomoStateVersionService cocomoStateVersionService)
        {
            _cocomoStateVersionService = cocomoStateVersionService;
        }

        // GET: api/CocomoStateVersion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocomoStateVersionReadDTO>>> GetCocomoStatesVersion()
        {
            var cocomoStatesVersion = await _cocomoStateVersionService.GetAllCocomoStatesVersionAsync();
            return Ok(cocomoStatesVersion);
        }

        // GET: api/CocomoStateVersion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CocomoStateVersionReadDTO>> GetCocomoStateVersion(int id)
        {
            var cocomoStateVersion = await _cocomoStateVersionService.GetCocomoStateVersionByIdAsync(id);

            if (cocomoStateVersion == null)
            {
                return NotFound();
            }

            return Ok(cocomoStateVersion);
        }

        // POST: api/CocomoStateVersion
        [HttpPost]
        public async Task<ActionResult<CocomoStateVersionReadDTO>> CreateCocomoVersionState(CocomoStateVersionCreateDTO cocomoStateVersionDto)
        {
            if (cocomoStateVersionDto == null)
            {
                return BadRequest();
            }

            var newCocomoStateVersion = await _cocomoStateVersionService.CreateCocomoStateVersionAsync(cocomoStateVersionDto);
            return CreatedAtAction(nameof(GetCocomoStateVersion), new { id = newCocomoStateVersion.Id }, newCocomoStateVersion);
        }

        // PUT: api/CocomoStateVersion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCocomoStateVersion(int id, CocomoStateVersionUpdateDTO cocomoStateVersionDto)
        {
            if (id != cocomoStateVersionDto.Id)
            {
                return BadRequest();
            }

            var result = await _cocomoStateVersionService.UpdateCocomoStateVersionAsync(id, cocomoStateVersionDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CocomoStateVersion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocomoStateVersion(int id)
        {
            var result = await _cocomoStateVersionService.DeleteCocomoStateVersionAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
