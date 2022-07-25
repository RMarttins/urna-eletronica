using HubCount.Urna.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubCount.Urna.Core.Repositories.EntityConfiguration
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("TB_VOTE");
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.CandidateId)
                .HasColumnName("CANDIDATE_ID");
            builder.Property(p => p.DtVote)
                .HasColumnName("DT_VOTE")
                .IsRequired();
            builder.Property(p => p.TypeVote)
                .HasColumnName("TYPE_VOTE")
                .HasColumnType("DECIMAL(1,0)")
                .IsRequired();
        }
    }
}