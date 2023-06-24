using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiSummonerDTO
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }
    }
}