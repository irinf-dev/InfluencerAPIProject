using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : Controller
    {
        private readonly ILogger<MarketsController> _logger;
        private readonly ApplicationDbContext _context;

        public MarketsController(ILogger<MarketsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarkets()
        {
            var markets = await _context.Markets.ToListAsync();
            return Ok(markets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarket([FromBody] Markets market)
        {
            if (market == null)
            {
                _logger.LogWarning("Received null niche object.");
                return BadRequest("Niche data is required.");
            }

            await _context.Markets.AddAsync(market);
            await _context.SaveChangesAsync();
            return Ok(market);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarket(int id)
        {
            var market = await _context.Markets.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }
            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarket(int id, [FromBody] Markets market)
        {
            var existingMarket = await _context.Markets.FindAsync(id);

            if (existingMarket == null)
            {
                _logger.LogWarning("Market with ID {Id} not found for update.", id);
                return NotFound();
            }

            existingMarket.MarketName = market.MarketName;
            await _context.SaveChangesAsync();
            return Ok(existingMarket);
        }
    }
}
