using HubCount.Urna.Core.Models.Base;
using HubCount.Urna.Core.Models.DTOs.Vote;
using HubCount.Urna.Core.Models.Reports;

namespace HubCount.Urna.Core.Services.Interfaces
{
    public interface IVoteService
    {
        Task<IEnumerable<VotesResult>?> GetResultAsync();
        Task<(BaseValidate?, VoteResponseDTO?)> CreateAsync(VoteCreateRequestDTO request);
    }
}