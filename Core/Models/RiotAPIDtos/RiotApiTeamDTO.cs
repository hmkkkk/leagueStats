using Newtonsoft.Json;

namespace Core.Models.RiotAPI
{
    public class RiotApiTeamDTO
    {
        [JsonProperty("bans")]
        public List<RiotApiBanDTO> Bans { get; set; }

        [JsonProperty("objectives")]
        public RiotApiObjectivesDTO Objectives { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }
    }

    public class RiotApiBanDTO
    {
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }

    public class RiotApiObjectivesDTO
    {
        [JsonProperty("baron")]
        public RiotApiObjectiveDTO Baron { get; set; }

        [JsonProperty("champion")]
        public RiotApiObjectiveDTO Champion { get; set; }

        [JsonProperty("dragon")]
        public RiotApiObjectiveDTO Dragon { get; set; }

        [JsonProperty("inhibitor")]
        public RiotApiObjectiveDTO Inhibitor { get; set; }

        [JsonProperty("riftHerald")]
        public RiotApiObjectiveDTO RiftHerald { get; set; }

        [JsonProperty("tower")]
        public RiotApiObjectiveDTO Tower { get; set; }
    }

    public class RiotApiObjectiveDTO
    {
        [JsonProperty("first")]
        public bool First { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }
    }
}