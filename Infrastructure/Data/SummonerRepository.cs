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

        public async Task<Summoner> GetSummonerByName(string name, string region, CancellationToken cancellationToken)
        {
            var query = _context.Summoners
                .Include(x => x.SummonerRanks)
                .Where(x => x.Name == name && x.Region == region)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Summoner> GetSummonerByPuuid(string puuid, string region, CancellationToken cancellationToken)
        {
            var query = _context.Summoners
                .Include(x => x.SummonerRanks)
                .Where(x => x.Puuid == puuid && x.Region == region)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<string> GetSummonerPuuid(string name, string region, CancellationToken cancellationToken)
        {
            return await _context.Summoners
                .Where(x => x.Name == name && x.Region == region)
                .Select(x => x.Puuid)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> SummonerExistsInDb(string puuid, CancellationToken cancellationToken)
        {
            return await _context.Summoners
                .Where(x => x.Puuid == puuid)
                .AnyAsync(cancellationToken);
        }

        public async Task UpdateSummoner(Summoner summoner, CancellationToken cancellationToken)
        {
            summoner.LastUpdated = DateTime.Now;

            _context.Entry(summoner).State = EntityState.Modified;

            _context.Entry(summoner).Property(p => p.Puuid).IsModified = false;
            _context.Entry(summoner).Property(p => p.SummonerId).IsModified = false;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSummonerRank(List<SummonerRank> ranks, string summonerId, CancellationToken cancellationToken)
        {
            var ranksFromDb = await _context.SummonerRanks
                .Where(x => x.SummonerId == summonerId)
                .ToListAsync(cancellationToken);
            
            var ranksToAdd = new List<SummonerRank>();

            foreach (var rank in ranks)
            {
                var rankFromDb = ranksFromDb.Where(x => x.QueueType == rank.QueueType).FirstOrDefault();

                if (rankFromDb == null) 
                {
                    ranksToAdd.Add(new SummonerRank
                    {
                        QueueType = rank.QueueType,
                        SummonerId = rank.SummonerId,
                        Tier = rank.Tier,
                        Rank = rank.Rank,
                        LeaguePoints = rank.LeaguePoints,
                        Losses = rank.Losses,
                        Wins = rank.Wins
                    });
                } 
                else 
                {
                    rankFromDb.Tier = rank.Tier;
                    rankFromDb.Rank = rank.Rank;
                    rankFromDb.LeaguePoints = rank.LeaguePoints;
                    rankFromDb.Losses = rank.Losses;
                    rankFromDb.Wins = rank.Wins;
                }
            }
            
            if (ranksToAdd.Count > 0) _context.AddRange(ranksToAdd);

            await _context.SaveChangesAsync();
        }
    }
}