using Core.Interfaces;
using Core.Models.RiotAPI;
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

        public async Task<SummonerDTO> GetSummonerByName(string region, string summonerName)
        {
            var client = BuildRestClient(region, false);

            var request = new RestRequest($"lol/summoner/v4/summoners/by-name/{summonerName}");
            request.AddHeader("X-Riot-Token", _riotApiKey);

            var response = await client.ExecuteGetAsync(request);

            if (!response.IsSuccessful) throw new HttpRequestException($"Failed to get summoner {summonerName}.", null, response.StatusCode);

            try
            {
                var obj = JsonConvert.DeserializeObject<SummonerDTO>(response.Content, _serializerSettings);

                return obj;
            }
            catch
            {
                throw new JsonSerializationException($"[GetSummonerByName] Could not deserialize response: {response.Content} to type SummonerDTO");
            }
        }

        public async Task<> GetSummonerMatches(string region, string puuid, int startIndex = 0, int pageSize = 15) 
        {

        }

        public async Task<List<string>> GetListOfMatchIds(string region, string puuid, int startIndex, int pageSize)
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