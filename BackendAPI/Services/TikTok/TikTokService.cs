using BackendAPI.Models.TikTok;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace BackendAPI.Services.TikTok
{
    public interface ITikTokService
    {
        Task<TikTokApiResponse<PublicAccInsights>> GetPublicAccInsights(string tto_tcm_account_id, string handle_name);
        Task<TikTokApiResponse<DiscoverCreatorResponse>> DiscoverCreators(string tto_tcm_account_id, string[] country_codes);
        Task<TikTokApiResponse<AuthorisedCreatorInsights>> GetAuthorisedCreatorInsights(string accessToken, string creator_id, string[] fields);
        Task<TikTokApiResponse<CreatorTokenResponse>> GetCreatorAccessToken(string authCode, string redirectUrl);
        Task<TikTokApiResponse<CreatorTokenResponse>> RefreshCreatorAccessToken(string refreshToken);
        Task<bool> RevokeCreatorAccessToken(string accessToken);
    }
    public class TikTokService : ITikTokService
    {
        private readonly HttpClient _httpClient;
        //private readonly string _accessToken;

        public TikTokService(HttpClient httpClient, IConfiguration configuration)
        {
            // This will help us send requests to the api to get data back
            _httpClient = httpClient;
            // I'll pull the value of the access token because I don't want it hardcoded
            //_accessToken = configuration["TikTok:AccessToken"];
        }

        // Task<TikTokResponse<DiscoverCreatorResponse>> means that we want data back in the form of that model
        public async Task<TikTokApiResponse<DiscoverCreatorResponse>> DiscoverCreators(string tto_tcm_account_id, string[] country_codes)
        {
            // Serialize the array so we don't get &country_codes=System.String[]
            string jsonString = JsonSerializer.Serialize(country_codes);

            var baseURL = $"https://business-api.tiktok.com/open_api/v1.3/tto/tcm/creator/discover/?tto_tcm_account_id={tto_tcm_account_id}&country_codes={jsonString}";

            // This creates request variable, uses get method and baseUrl to form request
            var request = new HttpRequestMessage(HttpMethod.Get, baseURL);
            // This creates the header that contains the access token. The value of the access token goes after the comma
            request.Headers.Add("Access-Token", "");

            // Send the request to the endpoint
            var response = await _httpClient.SendAsync(request);

            // This will ensure that the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializing is essentially converting a string into a C# Object. We read that response as a string and now we're converting it into a format matching <TikTokResponse<DiscoverCreatorResponse>>
            return JsonSerializer.Deserialize<TikTokApiResponse<DiscoverCreatorResponse>>(responseBody);
        }

        public async Task<TikTokApiResponse<PublicAccInsights>> GetPublicAccInsights(string tto_tcm_account_id, string handle_name)
        {
            var baseURL = $"https://business-api.tiktok.com/open_api/v1.3/tto/tcm/creator/public/?tto_tcm_account_id={tto_tcm_account_id}&handle_name={handle_name}";

            var request = new HttpRequestMessage(HttpMethod.Get, baseURL);

            request.Headers.Add("Access-Token", "");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TikTokApiResponse<PublicAccInsights>>(responseBody);
        }

        public async Task<TikTokApiResponse<AuthorisedCreatorInsights>> GetAuthorisedCreatorInsights(string accessToken, string creator_id, string[] fields)
        {
            string jsonFields = JsonSerializer.Serialize(fields);

            var baseURL = $"https://business-api.tiktok.com/open_api/v1.3/tto/creator/authorized/?creator_id={creator_id}&fields={jsonFields}";

            var request = new HttpRequestMessage(HttpMethod.Get, baseURL);

            request.Headers.Add("Access-Token", accessToken);

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TikTokApiResponse<AuthorisedCreatorInsights>>(responseBody);
        }

        public async Task<TikTokApiResponse<CreatorTokenResponse>> GetCreatorAccessToken(string authCode, string redirectUrl)
        {
            var baseURL = $"https://business-api.tiktok.com/open_api/v1.3/tt_user/oauth2/token/";

            var body = new
            {
                grant_type = "authorization_code",
                auth_code = authCode,
                client_secret = "5PKb0gNudJhbGE2BWGu5lhjWheTRlpYm",
                client_id = "sbawud47hfiuykzroj",
                redirectUri = redirectUrl
            };

            var request = new HttpRequestMessage(HttpMethod.Post, baseURL);

            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            // Don't forget to find out if you can edit the scope
            return JsonSerializer.Deserialize<TikTokApiResponse<CreatorTokenResponse>>(responseBody);
        }

        public async Task<TikTokApiResponse<CreatorTokenResponse>> RefreshCreatorAccessToken(string refreshToken)
        {
            var baseUrl = $"https://business-api.tiktok.com/open_api/v1.3/tt_user/oauth2/refresh_token/";

            var body = new
            {
                grant_type = "refresh_token",
                client_id = "sbawud47hfiuykzroj",
                client_secret = "5PKb0gNudJhbGE2BWGu5lhjWheTRlpYm",
                refresh_token = refreshToken
            };

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl);

            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TikTokApiResponse<CreatorTokenResponse>>(responseBody);
        }

        public async Task<bool> RevokeCreatorAccessToken(string accessToken)
        {
            var baseUrl = $"https://business-api.tiktok.com/open_api/v1.3/tt_user/oauth2/revoke/";

            var body = new
            {
                client_id = "",
                client_secret = "",
                access_token = accessToken
            };

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl);

            request.Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<TikTokApiResponse<object>>(responseBody);

            return result.IsSuccess;
        }
    }
}
