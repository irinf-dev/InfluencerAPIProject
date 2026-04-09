using System.Text.Json.Serialization;

namespace BackendAPI.Models.TikTok
{
    public class CreatorTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }

        [JsonPropertyName("open_id")]
        public string OpenId { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
