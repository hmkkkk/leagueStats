using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [PrimaryKey(nameof(Puuid))]
    public class Summoner
    {
        public string Puuid { get; set; }
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public long SummonerLevel { get; set; }
        public string SummonerId { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<SummonerRank> SummonerRanks { get; set; }
        public string Region { get; set; }
    }
}