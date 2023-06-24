using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiInfoDTO
    {
        [JsonProperty("gameCreation")]
        public long GameCreation { get; set; }

        [JsonProperty("gameDuration")]
        public int GameDuration { get; set; }

        [JsonProperty("gameEndTimestamp")]
        public long GameEndTimestamp { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("gameStartTimestamp")]
        public long GameStartTimestamp { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("participants")]
        public List<RiotApiParticipantDTO> Participants { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        [JsonProperty("teams")]
        public List<RiotApiTeamDTO> Teams { get; set; }

        [JsonProperty("tournamentCode")]
        public string TournamentCode { get; set; }        
    }   
}