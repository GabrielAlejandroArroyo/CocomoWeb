using CocomoBackend.Data;
using CocomoBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FormulasController : Controller
    {
        private readonly AppDbContext _context;
        public FormulasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formula>>> GetFormulas()
        {
            return await _context.Formulas.ToListAsync();
        }

    }
}
