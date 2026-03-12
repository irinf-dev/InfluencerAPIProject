using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NichesController : ControllerBase
    {
        private readonly ILogger<NichesController> _logger;
        private readonly ApplicationDbContext _context;

        public NichesController(ILogger<NichesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNiches()
        {
            var niches = await _context.Niches.ToListAsync();
            return Ok(niches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNicheById(int id)
        {
            var niche = await _context.Niches.FindAsync(id);
            if (niche == null)
            {
                _logger.LogWarning("Niche with ID {Id} not found.", id);
                return NotFound();
            }
            return Ok(niche);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNiche([FromBody] Niches niche)
        {
            if (niche == null)
            {
                _logger.LogWarning("Received null niche object.");
                return BadRequest("Niche data is required.");
            }

            await _context.Niches.AddAsync(niche);
            await _context.SaveChangesAsync();
            return Ok(niche);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNiche(int id)
        {
            var niche = await _context.Niches.FindAsync(id);
            if (niche == null)
            {
                _logger.LogWarning("Niche with ID {Id} not found for deletion.", id);
                return NotFound();
            }
            _context.Niches.Remove(niche);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNiche(int id, [FromBody] Niches niche)
        {
            var existingNiche = await _context.Niches.FindAsync(id);
            if (existingNiche == null)
            {
                _logger.LogWarning("Niche with ID {Id} not found for update.", id);
                return NotFound();
            }

            existingNiche.NicheName = niche.NicheName;
            await _context.SaveChangesAsync();
            return Ok(existingNiche);
        }
    }
}
