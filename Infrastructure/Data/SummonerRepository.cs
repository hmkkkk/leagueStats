using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SummonerRepository : ISummonerRepository
    {
        private readonly AppDbContext _context;

        public SummonerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Summoner> AddNewSummoner(Summoner summoner, CancellationToken cancellationToken)
        {
            summoner.LastUpdated = DateTime.Now;

            _context.Add(summoner);
            _context.Entry(summoner).State = EntityState.Added;

            await _context.SaveChangesAsync(cancellationToken);
            
            return summoner;
        }

        public async Task<Summoner> GetSummonerByName(string name, string region, bool withRanks, CancellationToken cancellationToken)
        {
            var query = _context.Summoners
                .Where(x => x.Name == name && x.Region == region)
                .AsQueryable();

            if (withRanks)
            {
                query.Include(x => x.SummonerRanks).AsQueryable();
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<string> GetSummonerPuuid(string name, string region, CancellationToken cancellationToken)
        {
            return await _context.Summoners
                .Where(x => x.Name == name && x.Region == region)
                .Select(x => x.Puuid)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> SummonerExistsInDb(string name, string region, CancellationToken cancellationToken)
        {
            return await _context.Summoners
                .Where(x => x.Name == name && x.Region == region)
                .AnyAsync(cancellationToken);
        }

        public async Task UpdateSummoner(Summoner summoner, CancellationToken cancellationToken)
        {
            summoner.LastUpdated = DateTime.Now;

            _context.Entry(summoner).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}