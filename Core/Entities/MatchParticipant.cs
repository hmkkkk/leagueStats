using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [PrimaryKey(nameof(MatchId), nameof(Puuid))]
    public class MatchParticipant
    {
        public string MatchId { get; set; }
        public string Puuid { get; set; }
        public Match Match { get; set; } = null!;
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int CreepScore { get; set; }
        public int VisionScore { get; set; }
        public int WardsBought { get; set; }
        public int ChampionLevel { get; set; }
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int ChampionTransform { get; set; }
        public int DoubleKills { get; set; }
        public int TripleKills { get; set; }
        public int QuadraKills { get; set; }
        public int PentaKills { get; set; }
        public int GoldEarned { get; set; }
        public string TeamPosition { get; set; }
        public string SummonerName { get; set; }
        public string Items { get; set; }
        public int ProfileIcon { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Id { get; set; }
        public int TotalDamageDealtToChampions { get; set; }
        public bool Win { get; set; }
        public int PrimaryRuneId { get; set; }
        public string PrimaryRunePerks { get; set; }
        public int SecondaryRuneId { get; set; }
        public string SecondaryRunePerks { get; set; }
        public string StatPerks { get; set; }
    }
}