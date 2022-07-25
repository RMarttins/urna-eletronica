namespace HubCount.Urna.Core.Models.DTOs.Candidate
{
    public class CandidateCreateRequestDTO
    {
        public string? CandidateName { get; set; }
        public string? ViceName { get; set; }
        public int Legenda { get; set; }
        public string? Partido { get; set; }
    }
}