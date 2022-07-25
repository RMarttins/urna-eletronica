using AutoMapper;
using HubCount.Urna.Core.Models.DTOs.Candidate;
using HubCount.Urna.Core.Models.DTOs.Vote;
using HubCount.Urna.Core.Models.Entities;

namespace HubCount.Urna.Core.AutoMapper
{
    public class DTOToEntityMapping : Profile
    {
        public DTOToEntityMapping()
        {
            CreateMap<CandidateCreateRequestDTO, Candidate>();
            CreateMap<CandidateUpdateRequestDTO, Candidate>();
            CreateMap<VoteCreateRequestDTO, Vote>();
        }
    }
}