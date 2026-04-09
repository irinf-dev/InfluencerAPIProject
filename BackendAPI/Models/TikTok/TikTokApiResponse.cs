using System.Text.Json.Serialization;

// This was created because of the way the response from the endpoint is structured

namespace BackendAPI.Models.TikTok
{
    // <T> is a placeholder for the model
    public class TikTokApiResponse<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName ("message")]
        public string Message { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
