using CocomoBackend.DTOs;
using CocomoBackend.Models;
using Microsoft.AspNetCore.Mvc;
using CocomoBackend.Services;

namespace CocomoBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformObjectTimeController : Controller
    {

        private readonly IPlatformObjectTimeService _platformObjectTimeService;

        public PlatformObjectTimeController(IPlatformObjectTimeService platformObjectTimeService)
        {
            _platformObjectTimeService = platformObjectTimeService;
        }

        // GET: api/PlatformObjectTime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformObjectTimeReadDTO>>> GetPlatformObjectTime()
        {
            var platformObjectTime = await _platformObjectTimeService.GetAllPlatformObjectTimesAsync();
            return Ok(platformObjectTime);
        }

        // GET: api/PlatformObjectTime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformObjectTimeReadDTO>> GetPlatformObjectTime(int id)
        {
            var platformObjectTime = await _platformObjectTimeService.GetPlatformObjectTimeByIdAsync(id);

            if (platformObjectTime == null)
            {
                return NotFound();
            }

            return Ok(platformObjectTime);
        }

        // POST: api/PlatformObjectTime
        [HttpPost]
        public async Task<ActionResult<PlatformObjectTimeReadDTO>> CreatePlatformObjectTime(PlatformObjectTimeCreateDTO platformObjectTimeDto)
        {
            if (platformObjectTimeDto == null)
            {
                return BadRequest();
            }

            var newPlatformObjectTime = await _platformObjectTimeService.CreatePlatformObjectTimeAsync(platformObjectTimeDto);
            return CreatedAtAction(nameof(GetPlatformObjectTime), new { id = newPlatformObjectTime.Id }, newPlatformObjectTime);
        }

        // PUT: api/PlatformObjectTime/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatformObjectTime(int id, PlatformObjectTimeUpdateDTO platformObjectTimeDto)
        {
            if (id != platformObjectTimeDto.Id)
            {
                return BadRequest();
            }

            var result = await _platformObjectTimeService.UpdatePlatformObjectTimeAsync(id, platformObjectTimeDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/PlatformObjectTime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _platformObjectTimeService.DeletePlatformObjectTimeAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
