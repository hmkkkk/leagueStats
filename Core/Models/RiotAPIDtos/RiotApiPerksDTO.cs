using Newtonsoft.Json;

namespace Core.Models.RiotAPI
{
    public class RiotApiPerksDTO
    {
        [JsonProperty("statPerks")]
        public RiotApiPerkStatsDTO StatPerks { get; set; }

        [JsonProperty("styles")]
        public List<RiotApiPerkStyleDTO> Styles { get; set; }
    }

    public class RiotApiPerkStatsDTO
    {
        [JsonProperty("defense")]
        public int Defense { get; set; }

        [JsonProperty("flex")]
        public int Flex { get; set; }

        [JsonProperty("offense")]
        public int Offense { get; set; }
    }

    public class RiotApiPerkStyleDTO
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selections")]
        public List<RiotApiPerkStyleSelectionDTO> Selections { get; set; }

        [JsonProperty("style")]
        public int Style { get; set; }
    }

    public class RiotApiPerkStyleSelectionDTO
    {
        [JsonProperty("perk")]
        public int Perk { get; set; }

        [JsonProperty("var1")]
        public int Var1 { get; set; }

        [JsonProperty("var2")]
        public int Var2 { get; set; }

        [JsonProperty("var3")]
        public int Var3 { get; set; }
    }
}