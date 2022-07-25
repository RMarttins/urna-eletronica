using AutoMapper;
using HubCount.Urna.Core.Models.Base;
using HubCount.Urna.Core.Models.DTOs.Vote;
using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Models.Enums;
using HubCount.Urna.Core.Models.Reports;
using HubCount.Urna.Core.Repositories.Interfaces;
using HubCount.Urna.Core.Services.Interfaces;

namespace HubCount.Urna.Core.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICandidateService _candidateService;
        private readonly BaseValidate validate = new();

        public VoteService(IVoteRepository repo, IMapper mapper, ICandidateService candidateService)
        {
            _repo = repo;
            _mapper = mapper;
            _candidateService = candidateService;
        }

        public async Task<(BaseValidate?, VoteResponseDTO?)> CreateAsync(VoteCreateRequestDTO request)
        {
            var vote = _mapper.Map<Vote>(request);
            ValidateRequest(vote);

            if (validate.HasError)
                return (validate, null);

            vote.DtVote = DateTime.Now;
            var result = await _repo.AddAsync(vote);
            return (validate, _mapper.Map<VoteResponseDTO>(result));
        }

        public async Task<IEnumerable<VotesResult>?> GetResultAsync()
        {
            return await _repo.GetVotesResultAsync();
        }

        private void ValidateRequest(Vote vote)
        {
            ValidateRequestData(vote);

            if (validate.HasError)
                return;

            if (vote.TypeVote == (int)TypeVote.VALIDO && vote.CandidateId != null)
                ValidateIfCandidateExists(vote);
            else
                //Insere NULL no candidatoID para salvar os votos nulos ou em brancos
                vote.CandidateId = null;
        }

        private void ValidateIfCandidateExists(Vote vote)
        {
            var candidate = _candidateService.GetByIdAsync(vote.CandidateId).Result;

            if (candidate == null)
            {
                validate.HasError = true;
                validate.ErrorMessage = "Candidato não encontrado.";
            }
        }

        private void ValidateRequestData(Vote? vote)
        {
            var errors = new List<string>();

            if ((vote?.CandidateId == null || vote?.CandidateId == 0) && vote?.TypeVote == (int)TypeVote.VALIDO)
                errors.Add(nameof(vote.CandidateId));
            if (vote?.TypeVote == null || vote?.TypeVote == 0)
                errors.Add(nameof(vote.TypeVote));

            if (errors.Count != 0)
            {
                validate.HasError = true;
                validate.ErrorMessage = $"Parametro(s) inválido(s): {String.Join(',', errors.ToArray())}";
            }
        }

    }
}