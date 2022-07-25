using HubCount.Urna.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HubCount.Urna.Core.Repositories.Extension
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeeData(this ModelBuilder builder)
        {

            builder.Entity<Candidate>().HasData(
                new Candidate { Id = 1, CandidateName = "Canditato Teste 001", ViceName = "Vice Canditato Teste 001", Legenda = 10, Partido = "SOLID", DtCreate = DateTime.Now },
                new Candidate { Id = 2, CandidateName = "Canditato Teste 002", ViceName = "Vice Canditato Teste 002", Legenda = 20, Partido = "CQRS", DtCreate = DateTime.Now },
                new Candidate { Id = 3, CandidateName = "Canditato Teste 003", ViceName = "Vice Canditato Teste 003", Legenda = 30, Partido = "DDD", DtCreate = DateTime.Now },
                new Candidate { Id = 4, CandidateName = "Canditato Teste 004", ViceName = "Vice Canditato Teste 004", Legenda = 40, Partido = "TDD", DtCreate = DateTime.Now },
                new Candidate { Id = 5, CandidateName = "Canditato Teste 005", ViceName = "Vice Canditato Teste 005", Legenda = 50, Partido = "BDD", DtCreate = DateTime.Now },
                new Candidate { Id = 6, CandidateName = "Canditato Teste 006", ViceName = "Vice Canditato Teste 006", Legenda = 60, Partido = "GIT", DtCreate = DateTime.Now });

            return builder;
        }
    }
}