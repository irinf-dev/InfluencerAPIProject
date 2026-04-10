namespace BackendAPI.Models.DTO
{
    public class YoutubeVideoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ChannelId { get; set; }

        public ulong ViewCount { get; set; }
        public ulong LikeCount { get; set; }
        public ulong CommentCount { get; set; }

        // Pre-calculated engagement rate
        public double EngagementRate { get; set; }
    }
}
