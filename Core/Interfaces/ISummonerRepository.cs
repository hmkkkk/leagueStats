using Core.Entities;

namespace Core.Interfaces
{
    public interface ISummonerRepository
    {
        Task<string> GetSummonerPuuid(string name, string region, CancellationToken cancellationToken);
        Task<bool> SummonerExistsInDb(string puuid, CancellationToken cancellationToken);
        Task<Summoner> AddNewSummoner(Summoner summoner, CancellationToken cancellationToken);
        Task UpdateSummoner(Summoner summoner, CancellationToken cancellationToken);
        Task<Summoner> GetSummonerByName(string name, string region, CancellationToken cancellationToken);
        Task<Summoner> GetSummonerByPuuid(string puuid, string region, CancellationToken cancellationToken);
        Task UpdateSummonerRank(List<SummonerRank> ranks, string summonerId, CancellationToken cancellationToken);
    }
}