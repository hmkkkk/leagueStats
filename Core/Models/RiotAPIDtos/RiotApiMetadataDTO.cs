using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiMetadataDTO
    {
        [JsonProperty("dataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("participants")]
        public List<string> Participants { get; set; }
    }
}