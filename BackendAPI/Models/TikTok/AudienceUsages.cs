using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AudienceUsages
    {
        [JsonPropertyName("percentage")]
        public float Percentage { get; set; }

        [JsonPropertyName("usage")]
        public string Usage {  get; set; }
    }
}
