namespace BackendAPI.Models
{
    public class InstagramMedia
    {
        public string Id { get; set; }
        public string Caption { get; set; }

        public string MediaType { get; set; } 
        public string MediaUrl { get; set; }
        public string Permalink { get; set; }

        public DateTime Timestamp { get; set; }  //could be used for content tracking on report/prediction side?

        public int LikeCount { get; set; }
        public int CommentsCount { get; set; }
    }
}
