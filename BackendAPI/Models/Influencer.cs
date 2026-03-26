using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    [Index(nameof(DisplayName), IsUnique = true)]
    public class Influencer 
    {
        ///<summary>
        /// The unique identifier for the influencer. This value can be left out because it is database generated
        ///</summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        ///<summary>
        /// The real name of the influencer
        ///</summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        ///<summary>
        /// The influencers display name
        ///</summary>
        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Platfrom { get; set; }

        /// <summary>
        /// This identifies the Influencers Niche
        /// </summary>
        public int NicheId { get; set; }
        [ForeignKey(nameof(NicheId))]
        public Niches? Niche { get; set; }

        /// <summary>
        /// This identifies the Influencers market
        /// </summary>
        public int MarketId { get; set; }
        [ForeignKey(nameof(MarketId))]
        public Markets? Market { get; set; }

        /// <summary>
        /// The Influencers previous collaborations
        /// </summary>
        public string[] PreviousCollaborations { get; set; }

        /// <summary>
        /// The influencers engagement rate (AVG Likes and Comments)
        /// </summary>
        public float EngagementRate { get; set; } //Avg Likes and comments

        [Required]
        [EmailAddress]
        [MaxLength(150)]

        public string Email { get; set; }

        /// <summary>
        /// The influencers Instagram handle
        /// </summary>
        [MaxLength(150)]

        public string InstagramHandle { get; set; }

        [MaxLength(150)]
        /// <summary>
        /// The Influencers Twitter/X handle
        /// </summary>
        public string TwitterHandle { get; set; }

        /// <summary>
        /// The influencers TikTok handle
        /// </summary>
        [MaxLength(150)]

        public string TikTokHandle { get; set; }

        /// <summary>
        /// The influencers YouTube handle
        /// </summary>
        [MaxLength(150)]

        public string YouTubeHandle { get; set; }
    }
}
