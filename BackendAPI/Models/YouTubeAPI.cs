namespace BackendAPI.Models
{
    // Root object returned by YouTube API.
    // Contains a list of items (videos, channels, etc.)
    
    public class YouTubeApiResponse
    {
        public List<Item> Items { get; set; }
    }

  
    // Represents each item in the API response.
    // Can contain snippet + statistics depending on endpoint.
    public class Item
    {
        // Used in search endpoint (videoId is nested)
        public IdInfo Id { get; set; }

        // Basic information (title, description, etc.)
        public Snippet Snippet { get; set; }

        // Engagement statistics (views, likes, comments)
        public Statistics Statistics { get; set; }
    }

    // Nested ID object used by search endpoint
    public class IdInfo
    {
        public string VideoId { get; set; }
    }

    // Contains basic video information
    public class Snippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChannelId { get; set; }
    }
    
    // Contains engagement metrics
    public class Statistics
    {
        public ulong ViewCount { get; set; }
        public ulong LikeCount { get; set; }
        public ulong CommentCount { get; set; }
    }
}
