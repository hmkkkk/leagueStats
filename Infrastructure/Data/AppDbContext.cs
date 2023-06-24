using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummonerRank>()
                .HasOne(r => r.Summoner)
                .WithMany(s => s.SummonerRanks)
                .HasForeignKey(r => r.SummonerId)
                .HasPrincipalKey(s => s.SummonerId);
        }

        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<SummonerRank> SummonerRanks { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchParticipant> MatchParticipants { get; set; }
    }
}