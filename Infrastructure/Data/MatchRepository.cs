using System.Collections.ObjectModel;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MatchRepository : IMatchRepository
    {
        private readonly AppDbContext _context;
        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMatches(List<Match> matches, CancellationToken cancellationToken)
        {
            _context.AddRange(matches);
            _context.Entry(matches).State = EntityState.Added;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<IReadOnlyList<Match>> GetMatchesForUser(string puuid, string region, CancellationToken cancellationToken, int pageNumber = 0, int pageSize = 15)
        {
            return await _context.Matches
                .Include(x => x.MatchParticipants)
                .Where(x => x.ParticipantPuuids.Contains(puuid))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<string>> GetAllMatchIdsForUser(string puuid, string region, CancellationToken cancellationToken)
        {
            return await _context.Matches
                .Include(x => x.MatchParticipants)
                .Where(x => x.ParticipantPuuids.Contains(puuid))
                .Select(x => x.MatchId)
                .ToListAsync(cancellationToken);
        }
    }
}