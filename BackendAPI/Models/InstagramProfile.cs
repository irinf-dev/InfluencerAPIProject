
namespace BackendAPI.Models
{
    /*
     A database table named InstagramProfile. Containing data pulled 
    from the Instagram Graph API represented by column names below.
     */

    //matches data to be retruned from GET /{user-id}?fields=...
    public class InstagramProfile
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string? Website { get; set; }

        public int FollowersCount { get; set; }
        public int FollowsCount { get; set; }
        public int MediaCount { get; set; }
    }
}
