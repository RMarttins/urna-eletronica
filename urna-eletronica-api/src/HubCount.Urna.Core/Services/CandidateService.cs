using AutoMapper;
using HubCount.Urna.Core.Models.Base;
using HubCount.Urna.Core.Models.DTOs.Candidate;
using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Repositories.Interfaces;
using HubCount.Urna.Core.Services.Interfaces;

namespace HubCount.Urna.Core.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repo;
        private readonly IMapper _mapper;
        private readonly BaseValidate validate = new();

        public CandidateService(ICandidateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateResponseDTO>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CandidateResponseDTO>>(result);
        }

        public async Task<CandidateResponseDTO?> GetByIdAsync(int? id)
        {
            var result = await _repo.GetByIdAsync(id);
            return _mapper.Map<CandidateResponseDTO>(result);
        }

        public async Task<CandidateResponseDTO?> GetByLegendaAsync(int legenda)
        {
            var result = await _repo.GetByLegenda(legenda);
            if (result != null)
                return _mapper.Map<CandidateResponseDTO?>(result);
            return null;
        }

        public async Task<CandidateResponseDTO?> GetByPartidoAsync(string partido)
        {
            var result = await _repo.GetByPartidoAsync(partido);
            if (result != null)
                return _mapper.Map<CandidateResponseDTO?>(result);
            return null;
        }

        public async Task<(BaseValidate?, CandidateResponseDTO?)> CreateAsync(CandidateCreateRequestDTO request)
        {
            var candidate = _mapper.Map<Candidate>(request);
            ValidateRequest(candidate);

            if (validate.HasError)
                return (validate, null);

            candidate.DtCreate = DateTime.Now;
            candidate.Partido = candidate.Partido.ToUpper();
            var result = await _repo.AddAsync(candidate);
            return (validate, _mapper.Map<CandidateResponseDTO>(result));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var candidate = await _repo.GetByIdAsync(id);
            if (candidate != null)
                return await _repo.DeleteAsync(candidate);

            return false;
        }


        #region Private Methods

        private void ValidateRequest(Candidate candidate)
        {
            ValidateIfLegendaExists(candidate.Legenda);
            ValidateIfPartidoExists(candidate.Partido);

            if (validate.HasError)
                return;

            ValidateRequestData(candidate);
        }

        private void ValidateIfLegendaExists(int legenda)
        {
            var result = GetByLegendaAsync(legenda).Result;
            if (result != null)
            {
                validate.HasError = true;
                validate.ErrorMessage = $"Legenda {legenda} já foi cadastrada.";
            }
        }

        private void ValidateIfPartidoExists(string partido)
        {
            var result = GetByPartidoAsync(partido).Result;
            if (result != null)
            {
                validate.HasError = true;
                validate.ErrorMessage = $"Já existe um candidato cadastrado para o partido {partido}.";
            }
        }

        private void ValidateRequestData(Candidate candidate)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(candidate?.CandidateName?.Trim()))
                errors.Add(nameof(candidate.CandidateName));
            if (string.IsNullOrEmpty(candidate?.ViceName?.Trim()))
                errors.Add(nameof(candidate.ViceName));
            if (candidate?.Legenda == 0 || candidate?.Legenda == null)
                errors.Add(nameof(candidate.Legenda));
            if (candidate?.Legenda < 10 || candidate?.Legenda > 99)
                errors.Add("A legenda dever ser maior que 9 e menor que 100");
            if (string.IsNullOrEmpty(candidate?.Partido?.Trim()))
                errors.Add(nameof(candidate.Partido));
            if (candidate?.Partido?.Length > 10)
                errors.Add("O partido não dever conter mais que 10 caracteres.");

            if (errors.Count != 0)
            {
                validate.HasError = true;
                validate.ErrorMessage = $"Parametro(s) inválido(s): \n - {String.Join("\n - ", errors.ToArray())}";
            }
        }

        #endregion
    }
}