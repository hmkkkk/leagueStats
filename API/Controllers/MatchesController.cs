using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MatchesController : BaseApiController
    {
        private readonly IMatchRepository _matchRepo;
        private readonly ISummonerRepository _summonerRepo;
        private readonly IMapper _mapper;
        public MatchesController(IMatchRepository matchRepo, ISummonerRepository summonerRepo, IMapper mapper)
        {
            _mapper = mapper;
            _summonerRepo = summonerRepo;
            _matchRepo = matchRepo;
        }

        [HttpGet("{region}/{name}")]
        public async Task<ActionResult<List<MatchDTO>>> GetSummonersMatchHistory(string name, string region, 
                CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 5)
        {
            string puuid = await _summonerRepo.GetSummonerPuuid(name, region, cancellationToken);

            var matches = await _matchRepo.GetMatchesForUser(puuid, region, cancellationToken, pageNumber, pageSize);

            return _mapper.Map<List<MatchDTO>>(matches);
        }
    }
}