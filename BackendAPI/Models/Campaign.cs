using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Campaign
    {

        /// <summary>
        /// The unique identifier for the campaign
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        /// <summary>
        /// The title of the campaign
        /// </summary>
        [Required]
        public string Title { get; set; }


        /// <summary>
        /// The description of the campaign
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The target platform for the campaign
        /// </summary>
        [Required]
        public string TargetPlatform { get; set; }

        /// <summary>
        /// Campaign audience age minimum
        /// </summary>
        [Required]
        public int AudienceAgeMini  { get; set; }

        /// <summary>
        /// Campaign audience age max
        /// </summary>
        public int AudienceAgeMax { get; set; }

        /// <summary>
        /// Gender of audience
        /// </summary>
        public string AudienceGender { get; set; }

        /// <summary>
        /// Context Type of campaign
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Minimum followers for desired influencer
        /// </summary>
        public string MinimumFollowers { get; set; }

        /// <summary>
        /// Maximum followers for desired influencer
        /// </summary>
        public string MaximumFollowers { get; set; }

        /// <summary>
        /// Start date for campaign
        /// </summary>
        [Required]
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// End date for campaign
        /// </summary>
        [Required]
        public DateOnly EndDate { get; set; }


        /// <summary>
        /// Influencer ID
        /// </summary>

        public Guid? InfluencerId { get; set; } //Look into allowing the InfluencerId to be nullable just in case a campaign doesn't have an influencer yet
        public Influencer? Influencer { get; set; }

        //Look into adding a name field 


    }
}
