using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AudienceCountries
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("percentage")]
        public string Percentage { get; set; }
    }
}
