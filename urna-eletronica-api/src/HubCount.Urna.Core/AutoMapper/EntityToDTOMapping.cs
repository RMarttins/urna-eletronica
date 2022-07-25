using AutoMapper;
using HubCount.Urna.Core.Models.DTOs.Candidate;
using HubCount.Urna.Core.Models.DTOs.Vote;
using HubCount.Urna.Core.Models.Entities;

namespace HubCount.Urna.Core.AutoMapper
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<Candidate, CandidateResponseDTO>();
            CreateMap<Vote, VoteResponseDTO>();
        }
    }
}