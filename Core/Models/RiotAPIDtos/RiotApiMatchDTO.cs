using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiMatchDTO
    {
        [JsonProperty("metadata")]
        public RiotApiMetadataDTO Metadata { get; set; }

        [JsonProperty("info")]
        public RiotApiInfoDTO Info { get; set; }
    }
}