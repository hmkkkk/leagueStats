using API.Errors;
using Core.Interfaces;
using Core.Models.RiotAPI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult<SummonerDTO>> GetSummonerByName(string region, string name)
        {
            try 
            {
                SummonerDTO summonerDTO = await _client.GetSummonerByName(region, name);

                return summonerDTO;
            }
            catch (HttpRequestException ex) 
            {
                return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
            }
        }

        [HttpGet("{region}/{name}/history")]
        public async Task<ActionResult<List<string>>> GetSummonerByName(string region, string name, int startIndex = 0, int pageSize = 15)
        {
            try 
            {
                List<string> matchIds = await _client.GetListOfMatchIds(region, name, startIndex, pageSize);

                return matchIds;
            }
            catch (HttpRequestException ex) 
            {
                return StatusCode((int)ex.StatusCode, new ApiResponse((int)ex.StatusCode, ex.Message));
            }
        }
    }
}