using Microsoft.AspNetCore.Mvc;
using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;


namespace CocomoBackend.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CocomoStateController : ControllerBase
    {
        private readonly ICocomoStateService _cocomoStateService;

        public CocomoStateController(ICocomoStateService cocomoStateService)
        {
            _cocomoStateService = cocomoStateService;
        }

        // GET: api/CocomoState
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocomoStateReadDTO>>> GetCocomoStates()
        {
            var cocomoStates = await _cocomoStateService.GetAllCocomoStatesAsync();
            return Ok(cocomoStates);
        }

        // GET: api/CocomoState/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CocomoStateReadDTO>> GetCocomoState(int id)
        {
            var cocomoState = await _cocomoStateService.GetCocomoStateByIdAsync(id);

            if (cocomoState == null)
            {
                return NotFound();
            }

            return Ok(cocomoState);
        }

        // POST: api/CocomoState
        [HttpPost]
        public async Task<ActionResult<CocomoStateReadDTO>> CreateCocomoState(CocomoStateCreateDTO cocomoStateDto)
        {
            if (cocomoStateDto == null)
            {
                return BadRequest();
            }

            var newCocomoState = await _cocomoStateService.CreateCocomoStateAsync(cocomoStateDto);
            return CreatedAtAction(nameof(GetCocomoState), new { id = newCocomoState.Id }, newCocomoState);
        }

        // PUT: api/CocomoState/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCocomoState(int id, CocomoStateUpdateDTO cocomoStateDto)
        {
            if (id != cocomoStateDto.Id)
            {
                return BadRequest();
            }

            var result = await _cocomoStateService.UpdateCocomoStateAsync(id, cocomoStateDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CocomoState/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocomoState(int id)
        {
            var result = await _cocomoStateService.DeleteCocomoStateAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
