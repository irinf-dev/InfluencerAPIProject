namespace BackendAPI.Models
{
    //data about an Instagram Account, specifically metrics and demographics.
    public class AccountInsights
    {

        public int Reach { get; set; }
        public int Impressions { get; set; }
        public int ProfileViews { get; set; }

        public int? WebsiteClicks { get; set; }

        public int FollowerCount { get; set; }

        public Dictionary<string, int> AudienceByAge { get; set; } = new();

        public Dictionary<string, int> AudienceByCity { get; set; } = new();

        public Dictionary<string, int> AudienceByCountry { get; set; } = new();
    }
}
