using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AudienceGenders
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("percentage")]
        public float Percentage { get; set; }
    }
}
