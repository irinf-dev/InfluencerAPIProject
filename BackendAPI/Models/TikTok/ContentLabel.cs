using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class ContentLabel
    {
        [JsonPropertyName("label_id")]
        public string LabelId { get; set; }

        [JsonPropertyName("label_name")]
        public string LabelName { get; set; }
    }
}
