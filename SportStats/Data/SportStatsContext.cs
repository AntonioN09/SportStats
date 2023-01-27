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
        public DbSet<TeamInEvent> TeamsInEvents { get; set; }

        public SportStatsContext(DbContextOptions<SportStatsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-Many
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team);

            //Many-to-Many
            modelBuilder.Entity<TeamInEvent>()
                .HasKey(te => new {te.TeamId, te.EventId});

            modelBuilder.Entity<TeamInEvent>()
                .HasOne<Team>(te => te.Team)
                .WithMany(t => t.TeamsInEvents)
                .HasForeignKey(te => te.TeamId);

            modelBuilder.Entity<TeamInEvent>()
                .HasOne<Event>(te => te.Event)
                .WithMany(e => e.TeamsInEvents)
                .HasForeignKey(te => te.EventId);

            //One-to-One
            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Team)
                .WithOne(t => t.Manager)
                .HasForeignKey<Team>(t => t.ManagerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
