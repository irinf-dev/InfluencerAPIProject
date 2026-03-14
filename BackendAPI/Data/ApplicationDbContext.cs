using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

namespace BackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Markets> Markets { get; set; }
        public DbSet<Niches> Niches { get; set; }
    }
}