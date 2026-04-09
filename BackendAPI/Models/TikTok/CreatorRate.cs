using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class CreatorRate
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("rate")]
        public int Rate { get; set; }
    }
}
