using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class DiscoverCreatorResponse
    {
        [JsonPropertyName("handle_name")]
        public string HandleName { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("followers_count")]
        public string FollowersCount { get; set; }

        [JsonPropertyName("following_count")]
        public string FollowingCount { get; set; }

        [JsonPropertyName("likes_count")]
        public string LikesCount { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("videos_count")]
        public string VideoCount { get; set; }
    }
}
