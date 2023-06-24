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
                    dest => dest.MatchParticipants,
                    opt => opt.MapFrom(src => src.Info.Participants)
                )
                .ForMember(
                    dest => dest.ParticipantPuuids,
                    opt => opt.MapFrom(src => string.Join(',', src.Metadata.Participants))
                );

            CreateMap<RiotApiParticipantDTO, MatchParticipant>()
                .ForMember(
                    dest => dest.CreepScore,
                    opt => opt.MapFrom(src => src.TotalMinionsKilled + src.NeutralMinionsKilled)
                )
                .ForMember(
                    dest => dest.Items,
                    opt => opt.MapFrom(src => string.Join(',', new int[7] { src.Item0, src.Item1, src.Item2, src.Item3, src.Item4, src.Item5, src.Item6 }))
                )
                .ForMember(
                    dest => dest.PrimaryRuneId,
                    opt => opt.MapFrom(src => src.Perks.Styles[0].Style)
                )
                .ForMember(
                    dest => dest.SecondaryRuneId,
                    opt => opt.MapFrom(src => src.Perks.Styles[1].Style)
                )
                .ForMember(
                    dest => dest.PrimaryRunePerks,
                    opt => opt.MapFrom(src => string.Join(',', src.Perks.Styles[0].Selections.Select(x => x.Perk)))
                )
                .ForMember(
                    dest => dest.SecondaryRunePerks,
                    opt => opt.MapFrom(src => string.Join(',', src.Perks.Styles[1].Selections.Select(x => x.Perk)))
                )
                .ForMember(
                    dest => dest.StatPerks,
                    opt => opt.MapFrom(src => string.Join(',', new int[3] {src.Perks.StatPerks.Offense, src.Perks.StatPerks.Flex, src.Perks.StatPerks.Defense}))
                );

            CreateMap<RiotApiLeagueEntryDTO, SummonerRank>();
        }
    }
}