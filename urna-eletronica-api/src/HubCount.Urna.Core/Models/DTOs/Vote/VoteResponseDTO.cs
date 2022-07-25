namespace HubCount.Urna.Core.Models.DTOs.Vote
{
    public class VoteResponseDTO
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string? TypeVote { get; set; }
        public DateTime DtVote { get; set; }
    }
}