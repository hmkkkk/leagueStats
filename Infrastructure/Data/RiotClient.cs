using Core.Interfaces;
using Core.Models.RiotAPIDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Data
{
    public class RiotClient : IRiotClient
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };
        private readonly IConfiguration _config;
        private readonly string _riotApiKey;
        public RiotClient(IConfiguration config)
        {
            _config = config;
            _riotApiKey = _config["RiotApiKey"];
        }

        public async Task<RiotApiSummonerDTO> GetSummonerByName(string summonerName, string region)
        {
            var client = BuildRestClient(region, false);

            var request = new RestRequest($"lol/summoner/v4/summoners/by-name/{summonerName}");
            request.AddHeader("X-Riot-Token", _riotApiKey);

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful) throw new HttpRequestException($"Failed to get summoner {summonerName}.", null, response.StatusCode);

            try
            {
                var obj = JsonConvert.DeserializeObject<RiotApiSummonerDTO>(response.Content, _serializerSettings);

                return obj;
            }
            catch
            {
                throw new JsonSerializationException($"[GetSummonerByName] Could not deserialize response: {response.Content} to type SummonerDTO");
            }
        }

        public async Task<List<string>> GetListOfSummonerMatchIds(string puuid, string region, int startIndex = 0, int pageSize = 15)
        {
            var client = BuildRestClient(region, true);

            var request = new RestRequest($"lol/match/v5/matches/by-puuid/${puuid}/ids");
            request.AddHeader("X-Riot-Token", _riotApiKey);
            request.AddParameter("start", startIndex);
            request.AddParameter("count", pageSize);

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful) throw new HttpRequestException($"Failed to get match history IDs.", null, response.StatusCode);

            return JsonConvert.DeserializeObject<List<string>>(response.Content, _serializerSettings);
        }

        public async Task<List<RiotApiLeagueEntryDTO>> GetLeagueEntriesForSummoner(string summonerId, string region)
        {
            var client = BuildRestClient(region, false);

            var request = new RestRequest($"/lol/league/v4/entries/by-summoner/{summonerId}");
            request.AddHeader("X-Riot-Token", _riotApiKey);

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful) throw new HttpRequestException($"Failed to get league entries.", null, response.StatusCode);

            return JsonConvert.DeserializeObject<List<RiotApiLeagueEntryDTO>>(response.Content, _serializerSettings);
        }

        public async Task<List<RiotApiMatchDTO>> GetListOfSummonerMatchesByGameIds(List<string> matchIds, string region) 
        {
            List<RiotApiMatchDTO> matchesToReturn = new List<RiotApiMatchDTO>();
            
            foreach (string match in matchIds)
            {
                 matchesToReturn.Add(await GetMatchByGameId(match, region)); 
            }

            return matchesToReturn;
        }

        public async Task<RiotApiMatchDTO> GetMatchByGameId(string matchId, string region) 
        {
            var client = BuildRestClient(region, true);

            var request = new RestRequest($"lol/match/v5/matches/{matchId}");
            request.AddHeader("X-Riot-Token", _riotApiKey);

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful) throw new HttpRequestException($"Failed to get match historyby itd IDs. Match ID: {matchId}", null, response.StatusCode);

            return JsonConvert.DeserializeObject<RiotApiMatchDTO>(response.Content, _serializerSettings);
        }

        private RestClient BuildRestClient(string region, bool useRegionalRouting) {
            string regionHost = useRegionalRouting ? GetRegionalRoutingValue(region) : GetPlatformRoutingValue(region);
            string clientUri = $"https://{regionHost}.api.riotgames.com";
            return new RestClient(clientUri);
        }

        private string GetRegionalRoutingValue(string region) {
            return region switch
            {
                var x when (x == "euw" || x == "eune" || x == "tr" || x == "ru") => "europe",
                var x when (x == "na" || x == "br" || x == "las" || x == "lan") => "americas",
                var x when (x == "jp" || x == "kr") => "asia",
                _ => "sea"
            };
        }
        private string GetPlatformRoutingValue(string region) {
            return region switch 
            {
                "br" => "br1",
                "euw" => "euw1",
                "jp" => "jp1",
                "kr" => "kr",
                "lan" => "la1",
                "las" => "la2",
                "na" => "na1",
                "oce" => "oc1",
                "tr" => "tr1",
                "ru" => "ru",
                "ph" => "ph2",
                "sg" => "sg2",
                "th" => "th2",
                "tw" => "tw2",
                "vn" => "vn2",
                _ => "eun1"
            };
        }
    }
}