using BackendAPI.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendAPI.Services
{
    public class InstagramService : IInstagramService
    {
        private readonly HttpClient _httpClient; //HttpClient used to make HTTP requests(GET/POST etc)
        private readonly string _accessToken = "PLACE THE ACCESS TOKEN";  // Represents the access token required for authentication

        //constructor
        public InstagramService(HttpClient httpClient, IConfiguration config) {  //HttpClient calls external APIs
            _httpClient = httpClient;
            
            _accessToken = config["InstagramSettings:AccessToken"];     //gives access to configuration values for the access token from appsettings.json
        }

        //Fetching profile data
        public async Task<InstagramProfile> GetProfileAsync(string userId)
        {
            //the base url + fields representing specific data that will be returned + access token for auth
            string url = $"https://graph.facebook.com/v19.0/{userId}?fields=id,username,name,profile_picture_url,followers_count,follows_count,media_count&access_token={_accessToken}";
            //Sends the actual request(GET) and waits for response
            var response = await _httpClient.GetAsync(url);

            //validation to check if the request worked
            //returns an error if the API request wasn't successful
            if (!response.IsSuccessStatusCode) {
                throw new Exception("Error fetching profile");
            }

            /*Reading the response as a JSON string
             So the JSON string can be converted into an object
             */

            //reads the response as a JSON string
            var content = await response.Content.ReadAsStringAsync();

            //converts JSON string to an object
            var profile = JsonSerializer.Deserialize<InstagramProfile>(content);

            return profile;
        }

        //add err handling
        
        //returns Content data - posts, reels, caption, metrics
        public async Task<List<InstagramMedia>> GetMediaAsync(string userId) {

            //fields depend on data i intend on pulling and that which matches my Instagram media models
            //Calls the /media endpoint

            string url = $"https://graph.facebook.com/v19.0/{userId}/media?fields=id,caption,media_type,media_url,permalink,timestamp,like_count,comments_count&access_token={_accessToken}";
            
            //Sends request to get content data about a sepcific post.
            var response = await _httpClient.GetAsync(url);

            //read the response as JSON string
            var content = await response.Content.ReadAsStringAsync();

            //convert the string to an object and makes use of the Wrapper Model
            //MediaResponse matches the Wrapper model {data: [...] }
            var responseObject = JsonSerializer.Deserialize<MediaResponse>(content);

            //extracts and returns only meaningful part of API response, so instead of an object(that was converted from a JSON string) returning data/response like this: 
            /*
             {
                "data": [
                    { "id": "1", "caption": "Hello" }
            ],
            "paging": {
            "next": "https://..."
              }
            
            }

            which is NOT what C# expects, C# only expects […] not {data: […] } like the above. 
            So we use the wrapper model to extract only the meaningful part of the API response or that C# expects using responseObject.Data (ensuring only this part [] is extracted)
             */
            return responseObject.Data; 

        }

        //Metrics about post or reel
        public async Task<string> GetMediaInsightsAsync(string mediaId)
        {
            //try run this code else go to catch
            try
            {

                //Request URL
                string url = $"https://graph.facebook.com/{mediaId}/insights?metric=impressions,reach,engagement,saved,video_views,replies&access_token={_accessToken}";

                //Sending actual GET request to the Instagram Graph API
                var response = await _httpClient.GetAsync(url);

                //validation to confirm the status of the request sent
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Instagram API error: {response.StatusCode}");  //create an error along with its appropriate error code
                }

                //else
                //read the response as a JSON string
                var content = await response.Content.ReadAsStringAsync();

                //send content to controller
                return content; // forgot to deserialize
            }

            catch (Exception ex) {  //terminates any processes above if there's an err in try and runs block below
            //ex contains err info 

                //prints error message
                Console.WriteLine($"Error fetching media insights: {ex.Message}");

                //returns no data to controller because there was an error
                return null;
            }
        }

        
        public async Task<string> GetAccountInsightsAsync(string userId) {
            try
            {

                string url = $"https://graph.facebook.com/{userId}/insights?metric=impressions,reach,profile_views,website_clicks&access_token={_accessToken}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Instagram API error: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }

            catch (Exception ex) {

                Console.WriteLine($"Error fetching account insights: {ex.Message}");
                return null;

            }
        }



    }


}
