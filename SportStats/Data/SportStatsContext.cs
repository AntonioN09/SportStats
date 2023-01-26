using Microsoft.EntityFrameworkCore;
using SportStats.Models;

namespace SportStats.Data
{
    public class SportStatsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public SportStatsContext(DbContextOptions<SportStatsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
