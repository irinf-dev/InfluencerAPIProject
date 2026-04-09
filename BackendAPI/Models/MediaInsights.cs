namespace BackendAPI.Models
{
    public class MediaInsights
    {
        public string MediaId { get; set; } = string.Empty;

        // How many accounts saw this post (counts each unique account once)
        public int Reach { get; set; }

        // Total times the post was displayed (one account can contribute many)
        public int Impressions { get; set; }

        // Likes + comments + saves + shares combined by Instagram
        public int Engagement { get; set; }

        // How many accounts saved this post (bookmarked)
        public int Saved { get; set; }

        // Number of times the video was played (VIDEO/REEL only)
        public int? VideoViews { get; set; }     //NOT GUARANTEED & VERY DIFFICULT TO OBTAIN

        // Stories only — replies received on this story
        public int? Replies { get; set; }           //NOT GUARANTEED & VERY DIFFICULT TO OBTAIN
    }
}
