namespace HubCount.Urna.Core.Models.DTOs.Vote
{
    public class VoteCreateRequestDTO
    {
        public int CandidateId { get; set; }
        public int TypeVote { get; set; }
    }
}