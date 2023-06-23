using Core.Entities;

namespace Core.Interfaces
{
    public interface ISummonerRepository
    {
        Task<string> GetSummonerPuuid(string name, string region, CancellationToken cancellationToken);
        Task<bool> SummonerExistsInDb(string name, string region, CancellationToken cancellationToken);
        Task<Summoner> AddNewSummoner(Summoner summoner, CancellationToken cancellationToken);
        Task UpdateSummoner(Summoner summoner, CancellationToken cancellationToken);
        Task<Summoner> GetSummonerByName(string name, string region, bool withRanks, CancellationToken cancellationToken);
    }
}