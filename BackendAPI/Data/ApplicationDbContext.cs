using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;
using BackendAPI.Models.Entities;

namespace BackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Markets> Markets { get; set; }
        public DbSet<Niches> Niches { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<MessageTemplate> MessageTemplates { get; set; }
        public DbSet<TikTokSnapshot> TikTokSnapshot { get; set; }
    }
}