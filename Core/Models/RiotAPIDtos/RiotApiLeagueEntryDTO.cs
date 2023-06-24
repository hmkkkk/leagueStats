using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiLeagueEntryDTO
    {
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }
    }
}