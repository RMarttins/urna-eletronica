namespace HubCount.Urna.Core.Models.Reports
{
    public class VotesResult
    {
        public string? President { get; set; }
        public string? VicePresident { get; set; }
        public int Legenda { get; set; }
        public string? Partido { get; set; }
        public int TotalVotes { get; set; }
        public int TotalNulos { get; set; }
        public int TotalBrancos { get; set; }
        public int TotalValidos { get; set; }
    }
}