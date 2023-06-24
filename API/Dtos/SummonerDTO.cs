namespace API.Dtos
{
    public class SummonerDTO
    {
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public long SummonerLevel { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<SummonerRankDTO> SummonerRanks { get; set; } = new List<SummonerRankDTO>();
        public string Region { get; set; }
    }
}