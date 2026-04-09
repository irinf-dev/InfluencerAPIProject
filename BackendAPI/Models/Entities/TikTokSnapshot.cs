using BackendAPI.Models.TikTok;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models.Entities
{
    public class TikTokSnapshot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid InfluencerId { get; set; }

        [ForeignKey(nameof(InfluencerId))]
        public Influencer? influencer { get; set; }

        public DateTimeOffset SnapshotDate { get; set; }

        public string? ProfileImage { get; set; }

        public string DisplayName { get; set; }

        public string HandleName { get; set; }

        public string? Bio { get; set; }

        public string? ContentLabels { get; set; }

        public string? IndustryLabels { get; set; }

        public float EngagementRate { get; set; }

        public int FollowerCount { get; set; }

        public int FollowingCount { get; set; }

        public int LikesCount { get; set; }

        public int VideosCount { get; set; }

        public int MedianViews { get; set; }

        public string CountryCode { get; set; }

        public string? AudienceAges { get; set; }

        public string? AudienceCountries { get; set; }

        public string? AudienceGenders { get; set; }

        public string? AudienceUsages { get; set; }
    }
}
