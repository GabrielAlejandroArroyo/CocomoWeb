using Microsoft.AspNetCore.Mvc;
using CocomoBackend.DTOs;
using Microsoft.EntityFrameworkCore;
using CocomoBackend.Services.interfaces;

//namespace Prospection.Seed.Controllers
namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocomoHeadController : ControllerBase
    {
        private readonly ICocomoHeadService _cocomoHeadService;

        public CocomoHeadController(ICocomoHeadService cocomoHeadService)
        {
            _cocomoHeadService = cocomoHeadService;
        }


        // GET: api/CocomoHead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocomoHeadReadDTO>>> GetCocomoHeads()
        {
            var cocomoHeads = await _cocomoHeadService.GetAllCocomoHeadsAsync();
            return Ok(cocomoHeads);
        }

        // GET: api/CocomoHead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CocomoHeadReadDTO>> GetCocomoHead(int id)
        {
            var cocomoHead = await _cocomoHeadService.GetCocomoHeadByIdAsync(id);

            if (cocomoHead == null)
            {
                return NotFound();
            }

            return Ok(cocomoHead);
        }

        // POST: api/CocomoHead
        [HttpPost]
        public async Task<ActionResult<CocomoHeadReadDTO>> CreateCocomoHead(CocomoHeadCreateDTO cocomoHeadDto)
        {
            if (cocomoHeadDto == null)
            {
                return BadRequest();
            }
            try
            {
                var newCocomoHead = await _cocomoHeadService.CreateCocomoHeadAsync(cocomoHeadDto);
                return CreatedAtAction(nameof(GetCocomoHead), new { id = newCocomoHead.Id }, newCocomoHead);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("FOREIGN KEY"))
                {
                    // Manejar específicamente la violación de la clave foránea
                    return BadRequest($"Error: {ex.InnerException.Message}");
                }

                // Manejar otros posibles errores de base de datos
                return StatusCode(500, "Error al guardar los cambios. Por favor, inténtalo de nuevo.");
            }
            catch (Exception ex)
            {
                // Capturar cualquier otra excepción
                return StatusCode(500, $"Ocurrió un error: {ex.Message}");
            }


        }




        // PUT: api/CocomoHead/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCocomoHead(int id, CocomoHeadUpdateDTO cocomoHeadDto)
        {
            if (id != cocomoHeadDto.Id)
            {
                return BadRequest();
            }

            var result = await _cocomoHeadService.UpdateCocomoHeadAsync(id, cocomoHeadDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CocomoHead/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocomoHead(int id)
        {
            var result = await _cocomoHeadService.DeleteCocomoHeadAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/CocomoHead/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CocomoHeadReadDTO>>> SearchCocomoHeads(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] string? sortColumn = null,
            [FromQuery] bool sortDescending = false)
        {
            // Validar valores de paginación
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest("La página y el tamaño de página deben ser mayores a 0.");
            }

            try
            {
                // Llamar al servicio con parámetros de búsqueda y paginación
                var (cocomoHeads, totalRecords) = await _cocomoHeadService.GetCocomoHeadsAsync(page, pageSize, search, sortColumn, sortDescending);

                // Crear los metadatos de paginación para devolver en el encabezado de respuesta
                var paginationMetadata = new
                {
                    totalRecords,
                    page,
                    pageSize,
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                };

                // Añadir metadatos de paginación a los encabezados de la respuesta
                Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(cocomoHeads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error: {ex.Message}");
            }
        }

        // GET: api/CocomoHead/searchopcional
        //[HttpGet("searchopcional")]
        //public async Task<IActionResult> Search([FromQuery] CocomoHeadSearchDTO searchDto)
        //{
        //    var results = await _cocomoHeadService.SearchCocomoHeadsAsync(searchDto);

        //    // Añadir metadatos de paginación a los encabezados de la respuesta
        //    //Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));


        //    return Ok(results);
        //}

        // POST: api/CocomoHead/searchopcionalnew
        //[HttpGet("searchopcionalnew")]
        [HttpPost("searchopcionalnew")]
        public async Task<ActionResult<IEnumerable<CocomoHeadReadDTO>>> Searchnew(int page, int pageSize  ,CocomoHeadSearchDTO searchDto)
        {

            // Validar valores de paginación
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest("La página y el tamaño de página deben ser mayores a 0.");
            }

            try
            {
                
                var (cocomoHeads, totalRecords) = await _cocomoHeadService.GetCocomoHeadsAsync(page, pageSize, searchDto);

                // Crear los metadatos de paginación para devolver en el encabezado de respuesta
                var paginationMetadata = new
                {
                    totalRecords,
                    page,
                    pageSize,
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                };

                // Añadir metadatos de paginación a los encabezados de la respuesta
                Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(cocomoHeads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error: {ex.Message}");
            }            
        }

    }
}
