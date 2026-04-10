using System.Collections.Generic;
using System.Threading.Tasks;
using BackendAPI.Models.DTO;

namespace BackendAPI.Services
{
    public interface IYouTubeService //interface defining the contract for YouTube-related operations, such as searching for videos and retrieving video details by ID.
    {
        Task<List<YoutubeVideoDto>> SearchVideosAsync(string query);
        Task<YoutubeVideoDto> GetVideoByIdAsync(string id);
    }
}
