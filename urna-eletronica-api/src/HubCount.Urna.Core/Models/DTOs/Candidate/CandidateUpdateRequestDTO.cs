namespace HubCount.Urna.Core.Models.DTOs.Candidate
{
    public class CandidateUpdateRequestDTO
    {
        public int Id { get; set; }
        public string? CandidateName { get; set; }
        public string? ViceName { get; set; }
        public int Legenda { get; set; }
        public string? Partido { get; set; }
    }
}