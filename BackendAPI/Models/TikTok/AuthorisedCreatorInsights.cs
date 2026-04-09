using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AuthorisedCreatorInsights
    {
        [JsonPropertyName("audience_ages")]
        public List<AudienceAge> AudienceAges { get; set; }

        [JsonPropertyName("audience_countries")]
        public List<AudienceCountries> AudienceCountries { get; set; }

        [JsonPropertyName("audience_devices")]
        public List<AudienceDevices> AudienceDevices { get; set; }

        [JsonPropertyName("audience_genders")]
        public List<AudienceGenders> AudienceGenders { get; set; }

        [JsonPropertyName("audience_usage")]
        public List<AudienceUsages> AudienceUsages { get; set; }

        [JsonPropertyName("bio")]
        public string Bio {  get; set; }

        [JsonPropertyName("content-labels")]
        public List<ContentLabel> ContentLabels { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("creator_rate")]
        public List<CreatorRate> CreatorRates { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("followers_count")]
        public int FollowersCount { get; set; }

        [JsonPropertyName("following_count")]
        public int FollowingCount { get; set; }

        [JsonPropertyName("handle_name")]
        public string HandleName { get; set; }

        [JsonPropertyName("industry_labels")]
        public List<IndustryLabel> IndustryLabels { get; set; }

        [JsonPropertyName("likes_count")]
        public int LikesCount { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("videos_count")]
        public int VideoCount { get; set; }
    }
}
