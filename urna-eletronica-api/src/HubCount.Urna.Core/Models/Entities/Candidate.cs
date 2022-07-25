namespace HubCount.Urna.Core.Models.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string? CandidateName { get; set; }
        public string? ViceName { get; set; }
        public DateTime DtCreate { get; set; }
        public int Legenda { get; set; }
        public string? Partido { get; set; }
        public IEnumerable<Vote>? Votes { get; set; }
    }
}