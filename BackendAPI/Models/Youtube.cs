using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Youtube
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChannelId { get; set; }

        public ulong ViewCount { get; set; }
        public ulong LikeCount { get; set; }
        public ulong CommentCount { get; set; }

        // Engagement Rate Calculation
        public double EngagementRate =>
            ViewCount > 0 ? (double)(LikeCount + CommentCount) / ViewCount : 0;
    }
}
