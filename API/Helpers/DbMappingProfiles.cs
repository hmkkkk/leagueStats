using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class DbMappingProfiles : Profile
    {
        public DbMappingProfiles()
        {
            CreateMap<Summoner, SummonerDTO>().ReverseMap();
            CreateMap<SummonerRank, SummonerRankDTO>().ReverseMap();
            CreateMap<Match, MatchDTO>().ReverseMap();
            CreateMap<MatchParticipant, MatchParticipantDTO>().ReverseMap();
        }
    }
}