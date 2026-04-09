using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models.Entities
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; }

        // The campaign related to the message
        public Guid CampaignId { get; set; }

        // The influencer receiving the message
        public Guid InfluencerId { get; set; }

        // Email or Instagram
        public string MessageType { get; set; }

        // Subject for email messages
        public string ? Subject { get; set; }

        // Message body
        public string MessageBody { get; set; }

        // If the company wants to type their own message
        public bool IsCustomMessage { get; set; }

        // Date sent
        public DateTime SentDate { get; set; }

        // Sent, Failed, Pending
        public string Status { get; set; }
    }
    }

