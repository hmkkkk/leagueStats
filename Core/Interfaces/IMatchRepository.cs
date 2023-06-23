using System.Collections.ObjectModel;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMatchRepository
    {
        Task<IReadOnlyList<Match>> GetMatchesForUser(string puuid, string region, CancellationToken cancellationToken, int pageNumber = 0, int pageSize = 15);
        Task<bool> AddMatches(List<Match> matches, CancellationToken cancellationToken);
        Task<List<string>> GetAllMatchIdsForUser(string puuid, string region, CancellationToken cancellationToken);
    }
}