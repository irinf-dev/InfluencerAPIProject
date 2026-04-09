using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AudienceAge
    {
        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("percentage")]
        public float Percentage { get; set; }
    }
}
