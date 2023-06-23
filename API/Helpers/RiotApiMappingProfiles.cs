using AutoMapper;
using Core.Entities;
using Core.Models.RiotAPIDtos;

namespace API.Helpers
{
    public class RiotApiMappingProfiles : Profile
    {
        public RiotApiMappingProfiles()
        {
            CreateMap<RiotApiSummonerDTO, Summoner>()
                .ForMember(
                    dest => dest.SummonerId,
                    opt => opt.MapFrom(src => src.Id)
                );

            CreateMap<RiotApiMatchDTO, Match>()
                .ForMember(
                    dest => dest.MatchId,
                    opt => opt.MapFrom(src => src.Metadata.MatchId)
                )
                .ForMember(
                    dest => dest.MatchDate,
                    opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeMilliseconds(src.Info.GameStartTimestamp).DateTime)
                )
                .ForMember(
                    dest => dest.QueueId,
                    opt => opt.MapFrom(src => src.Info.QueueId)
                )
                .ForMember(
                    dest => dest.ParticipantPuuids,
                    opt => opt.MapFrom(src => string.Join(',', src.Metadata.Participants))
                );

            CreateMap<RiotApiLeagueEntryDTO, SummonerRank>();
        }
    }
}