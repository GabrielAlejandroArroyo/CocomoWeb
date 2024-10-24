using Microsoft.AspNetCore.Mvc;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;


namespace CocomoBackend.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CocomoVersionController : ControllerBase
    {
        private readonly ICocomoVersionServices _cocomoVersionService;

        public CocomoVersionController(ICocomoVersionServices cocomoVersionService)
        {
            _cocomoVersionService = cocomoVersionService;
        }

        // GET: api/CocomoSVersion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocomoVersionReadDTO>>> GetCocomoVersion()
        {
            var cocomoVersion = await _cocomoVersionService.GetAllCocomoVersionsAsync();
            return Ok(cocomoVersion);
        }

        // GET: api/CocomoVersion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CocomoVersionReadDTO>> GetCocomoVersion(int id)
        {
            var cocomoVersion = await _cocomoVersionService.GetCocomoVersionByIdAsync(id);

            if (cocomoVersion == null)
            {
                return NotFound();
            }

            return Ok(cocomoVersion);
        }

        // POST: api/CocomoVersion
        [HttpPost]
        public async Task<ActionResult<CocomoVersionReadDTO>> CreateCocomoVersion(CocomoVersionCreateDTO cocomoVersionDto)
        {
            if (cocomoVersionDto == null)
            {
                return BadRequest();
            }

            var newCocomoVersion = await _cocomoVersionService.CreateCocomoVersionAsync(cocomoVersionDto);
            return CreatedAtAction(nameof(GetCocomoVersion), new { id = newCocomoVersion.Id }, newCocomoVersion);
        }

        // PUT: api/CocomoVersion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCocomoVersion(int id, CocomoVersionUpdateDTO cocomoVersionDto)
        {
            if (id != cocomoVersionDto.Id)
            {
                return BadRequest();
            }

            var result = await _cocomoVersionService.UpdateCocomoVersionAsync(id, cocomoVersionDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CocomoVersion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocomoVersion(int id)
        {
            var result = await _cocomoVersionService.DeleteCocomoVersionAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
