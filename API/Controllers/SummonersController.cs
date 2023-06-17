using API.Errors;
using Core.Interfaces;
using Core.Models.RiotAPI;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SummonersController : BaseApiController
    {
        private readonly IRiotClient _client;
        public SummonersController(IRiotClient client)
        {
            _client = client;
        }

        [HttpGet("{region}/{name}")]
        public async Task<ActionResult<RiotApiSummonerDTO>> GetSummonerByName(string region, string name)
        {
            try 
            {
                RiotApiSummonerDTO summonerDTO = await _client.GetSummonerByName(region, name);

                return summonerDTO;
            }
            catch (HttpRequestException ex) 
            {
                return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
            }
        }
    }
}