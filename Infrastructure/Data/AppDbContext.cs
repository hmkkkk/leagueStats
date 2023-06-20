using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<SummonerRank> SummonerRanks { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchParticipant> MatchParticipants { get; set; }
    }
}