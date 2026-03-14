namespace BackendAPI.Models
{
    public class Influencer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Niche { get; set; } = string.Empty;
        public string SocialHandle { get; set; } = string.Empty;
        public int Followers { get; set; }
        public string Platform { get; set; } = string.Empty; // Instagram, Twitter, TikTok, etc.
    }
}
