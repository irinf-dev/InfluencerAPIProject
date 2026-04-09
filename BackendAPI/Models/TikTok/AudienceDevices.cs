using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class AudienceDevices
    {
        [JsonPropertyName("device")]
        public string Device {  get; set; }

        [JsonPropertyName("percentage")]
        public float Percentage { get; set; }
    }
}
