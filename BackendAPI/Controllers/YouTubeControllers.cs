using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    
    
    // Controller responsible for handling HTTP requests
    // related to YouTube data.
   
    [ApiController]
    [Route("api/youtube")]
    public class YouTubeController : ControllerBase
    {
        private readonly IYouTubeService _youTubeService;

        public YouTubeController(IYouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

   
        // GET: api/youtube/videos?query=music
        // Searches for videos based on a keyword
       
        [HttpGet("videos")]
        public async Task<IActionResult> GetVideos([FromQuery] string query)
        {
            var result = await _youTubeService.SearchVideosAsync(query);

            // Returns HTTP 200 OK with data
            return Ok(result);
        }

    
        // GET: api/youtube/video/{id}
        // Retrieves detailed information about a single video
        
        [HttpGet("video/{id}")]
        public async Task<IActionResult> GetVideo(string id)
        {
            var result = await _youTubeService.GetVideoByIdAsync(id);

            // If video not found return 404
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

