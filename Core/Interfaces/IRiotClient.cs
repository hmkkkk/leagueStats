using Core.Models.RiotAPIDtos;

namespace Core.Interfaces
{
    public interface IRiotClient
    {
        Task<RiotApiSummonerDTO> GetSummonerByName(string summonerName, string region);
        Task<RiotApiSummonerDTO> GetSummonerByPuuid(string puuid, string region);
        Task<List<string>> GetListOfSummonerMatchIds(string puuid, string region, int startIndex = 0, int pageSize = 15);
        Task<List<RiotApiMatchDTO>> GetListOfSummonerMatchesByGameIds(List<string> matchIds, string region);
        Task<RiotApiMatchDTO> GetMatchByGameId(string matchId, string region);
        Task<List<RiotApiLeagueEntryDTO>> GetLeagueEntriesForSummoner(string summonerId, string region);
    }
}