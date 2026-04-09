using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Models.DTO;
using BackendAPI.Services.Instagram;
using BackendAPI.Models.Entities;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly MessageService _messageService;
        private readonly InstagramService _instagramService;

        public MessagingController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
            _messageService = new MessageService();
            _instagramService = new InstagramService();
        }

        [HttpPost("send-message")]
        //Make use of a DTO with the attribute [FromBody] unless you want the information to be passed as query parameters
        //Essentially api/send-message?campaignId=...&influencerId=...&messageType=...
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest sendMessageRequest)
        {
            var influencer = await _context.Influencers.FindAsync(sendMessageRequest.InfluencerId);
            var campaign = _context.Campaigns.Find(sendMessageRequest.CampaignId);

            if (influencer == null || campaign == null)
                return NotFound();

            string message = _messageService.GenerateDefaultMessage(influencer.Name, campaign.Title);

            string subject = "Campaign Opportunity";

            string status = "Pending";

            try
            {
                if (sendMessageRequest.MessageType == "Email")
                {
                    await _emailService.SendEmailAsync(influencer.Email, subject, message);
                }
                else if (sendMessageRequest.MessageType == "DM")
                {
                    _instagramService.SendDM(influencer.DisplayName, message);
                    subject = null; // DM doesn’t need subject
                }

                status = "Sent";
            }
            catch
            {
                status = "Failed";
            }

            // SAVE REPORT
            var report = new Report()
            {
                Id = Guid.NewGuid(),
                CampaignId = sendMessageRequest.CampaignId,
                InfluencerId = sendMessageRequest.InfluencerId,
                MessageType = sendMessageRequest.MessageType,
                Subject = subject,
                MessageBody = message,
                IsCustomMessage = false,
                SentDate = DateTime.Now,
                Status = status
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return Ok(report);
        }
    }
}
