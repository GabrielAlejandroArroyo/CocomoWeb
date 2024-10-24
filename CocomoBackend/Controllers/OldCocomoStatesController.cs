using CocomoBackend.Data;
using CocomoBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocomoBackend.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    public class OldCocomoStatesController : Controller
    {

        private readonly AppDbContext _context;

        public OldCocomoStatesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<CocomoState>>> GetCocomoStates()
        {
            return await _context.CocomoStates.ToListAsync();
        }


    }
}
