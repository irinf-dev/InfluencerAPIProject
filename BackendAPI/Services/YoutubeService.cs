using BackendAPI.Models;
using BackendAPI.Models.DTO;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;


namespace BackendAPI.Services
{
    public class YoutubeService : IYouTubeService
    {
        private readonly HttpClient _httpClient;

        // API Key (should ideally be stored in appsettings.json)
        private readonly string apiKey = "YOUR_API_KEY";

        public YoutubeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Searches for videos based on a query (e.g. "music")
        /// </summary>
        public async Task<List<YoutubeVideoDto>> SearchVideosAsync(string query)
        {
            //  Call YouTube Search API
            var searchUrl = $"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&q={query}&maxResults=5&key={apiKey}";
            var searchResponse = await _httpClient.GetAsync(searchUrl);

            // Check if request was successful
            if (!searchResponse.IsSuccessStatusCode)
                throw new Exception("Error fetching search results");

            // Convert response to JSON string
            var searchJson = await searchResponse.Content.ReadAsStringAsync();

            // Deserialize JSON into C# object
            var searchData = JsonSerializer.Deserialize<YouTubeApiResponse>(searchJson);

            var videos = new List<YoutubeVideoDto>();

            // Loop through each video returned
            foreach (var item in searchData.Items)
            {
                var videoId = item.Id.VideoId;

                // Call API again to get statistics (views, likes, etc.)
                var statsUrl = $"https://www.googleapis.com/youtube/v3/videos?part=statistics&id={videoId}&key={apiKey}";
                var statsResponse = await _httpClient.GetAsync(statsUrl);

                var statsJson = await statsResponse.Content.ReadAsStringAsync();
                var statsData = JsonSerializer.Deserialize<YouTubeApiResponse>(statsJson);

                var stats = statsData.Items.FirstOrDefault()?.Statistics;

                //  Map to internal model
                var video = new YoutubeVideoDto
                {
                    Id = videoId,
                    Title = item.Snippet.Title,
                    ChannelId = item.Snippet.ChannelId,
                    ViewCount = stats?.ViewCount ?? 0,
                    LikeCount = stats?.LikeCount ?? 0,
                    CommentCount = stats?.CommentCount ?? 0
                };

                // Convert to DTO
                videos.Add(new YoutubeVideoDto
                {
                    Id = video.Id,
                    Title = video.Title,
                    ChannelId = video.ChannelId,
                    ViewCount = video.ViewCount,
                    LikeCount = video.LikeCount,
                    CommentCount = video.CommentCount,
                    EngagementRate = video.EngagementRate
                });
            }

            return videos;
        }

        
        /// Retrieves detailed information for a single video
        public async Task<YoutubeVideoDto> GetVideoByIdAsync(string id)
        {
            var url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={id}&key={apiKey}"; // where we will be attaching the developer account
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error fetching video");

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<YouTubeApiResponse>(json);

            var item = data.Items.FirstOrDefault();

            // If no video found
            if (item == null)
                return null;

            var video = new YoutubeVideoDto
            {
                Id = id,
                Title = item.Snippet.Title,
                ChannelId = item.Snippet.ChannelId,
                ViewCount = item.Statistics?.ViewCount ?? 0,
                LikeCount = item.Statistics?.LikeCount ?? 0,
                CommentCount = item.Statistics?.CommentCount ?? 0
            };

            return new YoutubeVideoDto
            {
                Id = video.Id,
                Title = video.Title,
                ChannelId = video.ChannelId,
                ViewCount = video.ViewCount,
                LikeCount = video.LikeCount,
                CommentCount = video.CommentCount,
                EngagementRate = video.EngagementRate
            };
        }

        Task<YoutubeVideoDto> IYouTubeService.GetVideoByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

