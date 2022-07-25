using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Models.Reports;

namespace HubCount.Urna.Core.Repositories.Interfaces
{
    public interface IVoteRepository : IBaseRepository<Vote>
    {
        Task<IEnumerable<VotesResult>> GetVotesResultAsync();
    }
}