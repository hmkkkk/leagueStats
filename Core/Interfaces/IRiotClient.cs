using Core.Models.RiotAPI;

namespace Core.Interfaces
{
    public interface IRiotClient
    {
        Task<RiotApiSummonerDTO> GetSummonerByName(string region, string summonerName);
        Task<List<string>> GetListOfSummonerMatchIds(string region, string puuid, int startIndex = 0, int pageSize = 15);
        Task<List<RiotApiMatchDTO>> GetListOfSummonerMatchesByGameIds(string region, List<string> matchIds);
        Task<RiotApiMatchDTO> GetMatchByGameId(string region, string matchId);
    }
}