using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly ILogger<InfluencerController> _logger; // Logger for debugging
        private readonly ApplicationDbContext _context; // Database context for accessing the database

        public InfluencerController(ILogger<InfluencerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets all Influencers
        /// </summary>
        /// <returns>List of all Influencers</returns>

        // GET: api/Influencer - Retrieves a list of all influencers
        [HttpGet]
        public async Task<IActionResult> GetInfluencers()
        {
            var influencers = await _context.Influencers
                .Include(i => i.Niche)
                .Include(i => i.Market)
                .ToListAsync(); // Asynchronously retrieves all influencers from the database and returns them as a list
            return Ok(influencers); // Returns an HTTP 200 OK response with the list of influencers in the response body
        }

        /// <summary>
        /// Get an Influencer By ID
        /// </summary>
        /// <param name="id">The Influencers unique identifier</param>
        /// <returns></returns>

        // GET: api/Influencer/{id} - Retrieves a specific influencer by their unique identifier (ID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfluencerById(Guid id)
        {
            var influencer = await _context.Influencers
                .Include(i => i.Niche)
                .Include(i => i.Market)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (influencer == null)
            {
                _logger.LogInformation("Influencer with ID {Id} not found.", id);
                return NotFound();
            }
            return Ok(influencer);
        }

        /// <summary>
        /// Get an Influencer by display name
        /// </summary>
        /// <param name="displayName">The Influencers display name</param>
        /// <returns>Returns a single influencer</returns>

        // GET: api/Influencer/username/{displayName} - Retrieves a specific influencer by their display name
        [HttpGet("username/{displayName}")]
        public async Task<IActionResult> GetInfluencerByUsername(string displayName)
        {
            var influencer = await _context.Influencers
                .Include(i => i.Niche)
                .Include(i => i.Market)
                .FirstOrDefaultAsync(i => i.DisplayName == displayName);

            if (influencer == null)
            {
                _logger.LogInformation("Influencer with DisplayName {DisplayName} not found.", displayName);
                return NotFound();
            }
            return Ok(influencer);
        }

        /// <summary>
        /// Deletes an influencer by ID
        /// </summary>
        /// <param name="guid">The influencers unique identifier</param>
        /// <returns></returns>

        // DELETE: api/Influencer/{guid} - Deletes a specific influencer by their unique identifier (ID)
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteInfluencerById(Guid guid)
        {
            var influencer = await _context.Influencers.FindAsync(guid);
            if (influencer == null)
            {
                _logger.LogInformation("Influencer with ID {Id} not found for deletion.", guid);
                return NotFound();
            }
            _context.Influencers.Remove(influencer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Creates a new influencer
        /// </summary>
        /// <param name="influencer">The influencer object to create</param>
        /// <returns>The created influencer object</returns>

        // POST: api/Influencer - Creates a new influencer with the provided data
        [HttpPost]
        public async Task<IActionResult> CreateInfluencer([FromBody] Influencer influencer)
        {
            if (influencer == null)
            {
                _logger.LogWarning("Attempted to create an influencer with null data.");
                return BadRequest();
            }

            var userNameExists = await _context.Influencers.AnyAsync(i => i.DisplayName == influencer.DisplayName);
            if (userNameExists)
            {
                _logger.LogWarning("Attempted to create an influencer with an existing DisplayName: {DisplayName}.", influencer.DisplayName);
                return Conflict(new { message = "An influencer with the same DisplayName already exists." });
            }

            var influencerEntity = new Influencer
            {
                Name = influencer.Name,
                DisplayName = influencer.DisplayName,
                Platfrom = influencer.Platfrom,
                NicheId = influencer.NicheId,
                MarketId = influencer.MarketId,
                PreviousCollaborations = influencer.PreviousCollaborations,
                EngagementRate = influencer.EngagementRate,
                Email = influencer.Email,
                InstagramHandle = influencer.InstagramHandle,
                TwitterHandle = influencer.TwitterHandle,
                TikTokHandle = influencer.TikTokHandle,
                YouTubeHandle = influencer.YouTubeHandle
            };

            _context.Influencers.Add(influencerEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInfluencerById), new { id = influencerEntity.Id }, influencerEntity);
        }

        /// <summary>
        /// Updates an existing influencer
        /// </summary>
        /// <param name="influencerEntity">The updated influencer object</param>
        /// <param name="id">The influencers unique identifier</param>
        /// <returns></returns>

        // PUT: api/Influencer - Updates an existing influencer's information based on the provided data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInfluencerInformation(Guid id, [FromBody] Influencer InfluencerEntity)

        {
            var existingInfluencer = await _context.Influencers.FindAsync(id);
            if (existingInfluencer == null)
            {
                _logger.LogInformation("Influencer with ID {id} not found for update.", id);
                return NotFound();
            }

            existingInfluencer.Name = influencerEntity.Name;
            existingInfluencer.DisplayName = influencerEntity.DisplayName;
            existingInfluencer.Platfrom = influencerEntity.Platfrom;
            existingInfluencer.NicheId = influencerEntity.NicheId;
            existingInfluencer.MarketId = influencerEntity.MarketId;
            existingInfluencer.PreviousCollaborations = influencerEntity.PreviousCollaborations;
            existingInfluencer.EngagementRate = influencerEntity.EngagementRate;
            existingInfluencer.Email = influencerEntity.Email;
            existingInfluencer.InstagramHandle = influencerEntity.InstagramHandle;
            existingInfluencer.TwitterHandle = influencerEntity.TwitterHandle;
            existingInfluencer.TikTokHandle = influencerEntity.TikTokHandle;
            existingInfluencer.YouTubeHandle = influencerEntity.YouTubeHandle;

            _context.Influencers.Update(existingInfluencer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
