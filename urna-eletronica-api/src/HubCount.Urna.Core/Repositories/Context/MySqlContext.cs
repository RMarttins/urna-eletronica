using HubCount.Urna.Core.Models.Entities;
using HubCount.Urna.Core.Repositories.EntityConfiguration;
using HubCount.Urna.Core.Repositories.Extension;
using Microsoft.EntityFrameworkCore;

namespace HubCount.Urna.Core.Repositories.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());

            modelBuilder.SeeData();
        }
    }
}