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
        public async Task<ActionResult<RiotApiSummonerDTO>> GetSummonerByName(string name, string region, CancellationToken cancellationToken)
        {
            if (!await _summonerRepo.SummonerExistsInDb(name, region, cancellationToken))
            {
                try 
                {
                    await AddNewSummonerToDb(name, region, cancellationToken);
                }
                catch (HttpRequestException ex) 
                {
                    return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
                }
            }
                
            return BadRequest(); 
        }

        private async Task<Summoner> AddNewSummonerToDb(string name, string region, CancellationToken cancellationToken) 
        {
            var apiSummonerDTO = await _client.GetSummonerByName(region, name);

            var summoner = _mapper.Map<Summoner>(apiSummonerDTO);

            summoner.Region = region;

            return await _summonerRepo.AddNewSummoner(summoner, cancellationToken);
        }

        private async Task AddNewMatchesToDb(List<string> matchIdsFromDb, string puuid, string region, CancellationToken cancellationToken)
        {
            List<string> matchIdsFromApi = await _client.GetListOfSummonerMatchIds(puuid, region, 0, 20);

            matchIdsFromApi = matchIdsFromApi.Except(matchIdsFromDb).ToList();

            var matches = await _client.GetListOfSummonerMatchesByGameIds(matchIdsFromApi, region);

            
        }
    }
}