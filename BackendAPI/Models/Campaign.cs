using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Campaign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string TargetPlatform { get; set; }

        [Required]
        public int AudienceAgeMini  { get; set; }

        public int AudienceAgeMax { get; set; }

        public string AudienceGender { get; set; }

        public string ContentType { get; set; }

        public string MinimumFollowers { get; set; }
        public string MaximumFollowers { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        public Guid? InfluencerId { get; set; }
        public Influencer? Influencer { get; set; }

    }
}
