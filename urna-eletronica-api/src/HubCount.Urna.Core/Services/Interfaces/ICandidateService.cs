using HubCount.Urna.Core.Models.Base;
using HubCount.Urna.Core.Models.DTOs.Candidate;

namespace HubCount.Urna.Core.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateResponseDTO>> GetAllAsync();
        Task<CandidateResponseDTO?> GetByIdAsync(int? id);
        Task<CandidateResponseDTO?> GetByLegendaAsync(int legenda);
        Task<CandidateResponseDTO?> GetByPartidoAsync(string partido);
        Task<(BaseValidate?, CandidateResponseDTO?)> CreateAsync(CandidateCreateRequestDTO request);
        Task<bool> DeleteAsync(int id);
    }
}