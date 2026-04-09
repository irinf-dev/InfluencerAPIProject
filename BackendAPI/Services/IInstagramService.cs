using BackendAPI.Models;

namespace BackendAPI.Services

    //Created an interface to define what functions must exist
{
    public interface IInstagramService
    {
        Task<InstagramProfile> GetProfileAsync(string userId);
        Task<List<InstagramMedia>> GetMediaAsync(string userId);

        Task<string> GetMediaInsightsAsync(string mediaId);

        Task<string> GetAccountInsightsAsync(string userId);
    }
}
