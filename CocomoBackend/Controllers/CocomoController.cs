using CocomoBackend.DTOs;
using CocomoBackend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocomoController : ControllerBase
    {

        //private readonly ICocomoHeadService _cocomoHeadService;
        private readonly ICocomoService _cocomoService;


        public CocomoController(ICocomoService cocomoService)
        {
            _cocomoService = cocomoService;
        }

        // POST: api/Cocomo
        [HttpPost]
        public async Task<ActionResult<CocomoReadDTO>> CreateCocomo(CocomoHeadCreateDTO cocomoHeadDto)
        {

            if (cocomoHeadDto == null)
            {
                return BadRequest();
            }
            try
            {
                var newCocomo = await _cocomoService.CreateCocomoAsync(cocomoHeadDto);
                //return CreatedAtAction(nameof(GetCocomoHead), new { id = newCocomoHead.Id }, newCocomoHead);
                return newCocomo;
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


        // GET: api/Cocomo/5/Version/1
        [HttpGet("{idhead}/Version/{idversion}")]
        public async Task<ActionResult<CocomoReadDTO>> GetCocomo(int idhead, int idversion)
        {
            var cocomoHead = await _cocomoService.GetCococmoByIdAsync(idhead, idversion);

            if (cocomoHead == null)
            {
                return NotFound();
            }

            return Ok(cocomoHead);
        }

    }
}
