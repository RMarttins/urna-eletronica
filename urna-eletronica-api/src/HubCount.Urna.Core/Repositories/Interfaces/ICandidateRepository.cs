using HubCount.Urna.Core.Models.Entities;

namespace HubCount.Urna.Core.Repositories.Interfaces
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task<Candidate> GetByLegenda(decimal legenda);
        Task<Candidate> GetByPartidoAsync(string partido);
    }
}