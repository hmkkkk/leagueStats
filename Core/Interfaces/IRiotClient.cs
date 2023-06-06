using Core.Models.RiotAPI;

namespace Core.Interfaces
{
    public interface IRiotClient
    {
        Task<SummonerDTO> GetSummonerByName(string region, string summonerName);
        Task<List<string>> GetListOfMatchIds(string region, string puuid, int startIndex, int pageSize);
    }
}