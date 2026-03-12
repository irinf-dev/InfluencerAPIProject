using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    [Index(nameof(DisplayName), IsUnique = true)]
    public class Influencer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        public string Platfrom { get; set; }

        public int NicheId { get; set; }
        [ForeignKey(nameof(NicheId))]
        public Niches? Niche { get; set; }

        public int MarketId { get; set; }
        [ForeignKey(nameof(MarketId))]
        public Markets? Market { get; set; }

        public string[] PreviousCollaborations { get; set; }

        public float EngagementRate { get; set; } //Avg Likes and comments

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string InstagramHandle { get; set; }

        [MaxLength(150)]
        public string TwitterHandle { get; set; }

        [MaxLength(150)]
        public string TikTokHandle { get; set; }

        [MaxLength(150)]
        public string YouTubeHandle { get; set; }
    }
}
