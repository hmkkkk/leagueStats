using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models.RiotAPIDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SummonersController : BaseApiController
    {
        private readonly IRiotClient _client;
        private readonly IMatchRepository _matchRepo;
        private readonly ISummonerRepository _summonerRepo;
        private readonly IMapper _mapper;
        public SummonersController(IRiotClient client, ISummonerRepository summonerRepo, IMatchRepository matchRepo, IMapper mapper)
        {
            _mapper = mapper;
            _summonerRepo = summonerRepo;
            _matchRepo = matchRepo;
            _client = client;
        }

        [HttpGet("{region}/{name}")]
        public async Task<ActionResult<SummonerDTO>> GetSummonerByName(string name, string region, CancellationToken cancellationToken)
        {
            if (!await _summonerRepo.SummonerExistsInDb(name, region, cancellationToken))
            {
                try 
                {
                    var summoner = await GetSummonerWithRankFromApi(name, region, cancellationToken);

                    summoner = await _summonerRepo.AddNewSummoner(summoner, cancellationToken);

                    var matchIds = await _matchRepo.GetAllMatchIdsForUser(summoner.Puuid, region, cancellationToken);
 
                    await AddNewMatchesToDb(matchIds, summoner.Puuid, region, cancellationToken);
                }
                catch (HttpRequestException ex) 
                {
                    return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
                }
            }

            var summonerFromDb = await _summonerRepo.GetSummonerByName(name, region, cancellationToken);

            return _mapper.Map<SummonerDTO>(summonerFromDb);
        }

        [HttpGet("{region}/{name}/update")]
        public async Task<ActionResult<SummonerDTO>> UpdateSummonerData(string name, string region, CancellationToken cancellationToken)
        {
            if (!await _summonerRepo.SummonerExistsInDb(name, region, cancellationToken))
            {
                return RedirectToAction("GetSummonerByName", new { name = name, region = region, cancellationToken = cancellationToken});
            }

            try 
            {
                var summoner = await GetSummonerWithRankFromApi(name, region, cancellationToken);

                await _summonerRepo.UpdateSummoner(summoner, cancellationToken);
                await _summonerRepo.UpdateSummonerRank(summoner.SummonerRanks, summoner.SummonerId, cancellationToken);

                var matchIds = await _matchRepo.GetAllMatchIdsForUser(summoner.Puuid, region, cancellationToken);

                await AddNewMatchesToDb(matchIds, summoner.Puuid, region, cancellationToken);
            }
            catch (HttpRequestException ex) 
            {
                return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
            }

            var summonerFromDb = await _summonerRepo.GetSummonerByName(name, region, cancellationToken);

            return _mapper.Map<SummonerDTO>(summonerFromDb);
        }

        private async Task<Summoner> GetSummonerWithRankFromApi(string name, string region, CancellationToken cancellationToken) 
        {
            var apiSummonerDTO = await _client.GetSummonerByName(name, region);
            
            var summoner = _mapper.Map<Summoner>(apiSummonerDTO);

            var apiSummonerRanks = await _client.GetLeagueEntriesForSummoner(summoner.SummonerId, region);

            var summonerRanks = _mapper.Map<List<SummonerRank>>(apiSummonerRanks);

            summoner.SummonerRanks = summonerRanks;
            summoner.Region = region;

            return summoner;
        }

        private async Task AddNewMatchesToDb(List<string> matchIdsFromDb, string puuid, string region, CancellationToken cancellationToken)
        {
            List<string> matchIdsFromApi = await _client.GetListOfSummonerMatchIds(puuid, region, 0, 20);

            matchIdsFromApi = matchIdsFromApi.Except(matchIdsFromDb).ToList();

            var apiMatchesDTO = await _client.GetListOfSummonerMatchesByGameIds(matchIdsFromApi, region);

            var matches = _mapper.Map<List<Match>>(apiMatchesDTO);

            foreach (var match in matches)
            {
                match.MatchParticipants.ForEach(p => p.MatchId = match.MatchId);
                match.Region = region;
            }

            await _matchRepo.AddMatches(matches, cancellationToken);
        }
    }
}