using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class PublicAccInsights
    {
        [JsonPropertyName("bio")]
        public string Bio {  get; set; }

        [JsonPropertyName("content_labels")]
        public List<ContentLabel> ContentLabels { get; set; }

        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        [JsonPropertyName("creator_price")]
        public int CreatorPrice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency {  get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("engagement_rate")]
        public float EngagementRate { get; set; }

        [JsonPropertyName("followers_count")]
        public int FollowersCount { get; set; }

        [JsonPropertyName("following_count")]
        public int FollowingCount { get; set; }

        [JsonPropertyName("handle_name")]
        public string HandleName { get; set; }

        [JsonPropertyName("industry_labels")]
        public List<IndustryLabel> IndustryLabels { get; set; }

        [JsonPropertyName("likes_count")]
        public int IndustryCount { get; set; }

        [JsonPropertyName("median_views")]
        public int MedianViews {  get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("videos_count")]
        public int VideoCount { get; set; }
    }
}
