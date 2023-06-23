using API.Errors;
using Core.Interfaces;
using Core.Models.RiotAPIDtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MatchesController : BaseApiController
    {
        private readonly IRiotClient _client;
        public MatchesController(IRiotClient client)
        {
            _client = client;
        }

        [HttpGet("{region}/{name}")]
        public async Task<ActionResult<List<RiotApiMatchDTO>>> GetSummonersMatchHistory(string region, string name, int startIndex = 0, int pageSize = 3)
        {
            try 
            {
                List<string> matchIds = await _client.GetListOfSummonerMatchIds(region, name, startIndex, pageSize);

                return await _client.GetListOfSummonerMatchesByGameIds(matchIds, region);
            }
            catch (HttpRequestException ex) 
            {
                return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
            }
        }
    }
}