using BackendAPI.Data;
using BackendAPI.Services.TikTok;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/tiktok/auth")]
    public class TikTokController : ControllerBase
    {
        private readonly TikTokService _tikTokService;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public TikTokController(TikTokService tikTokService, 
            ILogger logger, ApplicationDbContext context)
        {
            _tikTokService = tikTokService;
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet("connect")]
        public async Task<IActionResult> Connect()
        {
            var state = Guid.NewGuid().ToString();

            var url = $"https://www.tiktok.com/v2/auth/authorize/?" +
                      $"client_key=" +
                      $"&response_type=code" +
                      $"&scope=user.info.basic" +
                      $"&redirect_uri=" +
                      $"&state={state}";

            return new RedirectResult(url);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback(string code, string state)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest("No code returned from TikTok");

            var redirectUrl = $"http://localhost:5186/api/tiktok/auth/callback";

            var token = await _tikTokService.GetCreatorAccessToken(code, redirectUrl);

            return Ok(token);
        }
    }
}
