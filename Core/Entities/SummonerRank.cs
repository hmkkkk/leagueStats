using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [PrimaryKey(nameof(QueueType), nameof(SummonerId))]
    public class SummonerRank
    {
        public string QueueType { get; set; }
        public string SummonerId { get; set; }
        public string Tier { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public Summoner Summoner { get; set; } = null!;
    }
}