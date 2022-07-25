namespace HubCount.Urna.Core.Models.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int TypeVote { get; set; }
        public DateTime DtVote { get; set; }
        public Candidate? Candidate { get; set; }
    }
}