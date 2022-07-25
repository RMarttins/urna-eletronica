using HubCount.Urna.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubCount.Urna.Core.Repositories.EntityConfiguration
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("TB_CANDIDATE");
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.CandidateName)
                .HasColumnName("CANDIDATE_NAME")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.ViceName)
                .HasColumnName("VICE_NAME")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.DtCreate)
                .HasColumnName("DT_CREATE")
                .IsRequired();
            builder.Property(p => p.Legenda)
                .HasColumnName("LEGENDA")
                .HasColumnType("DECIMAL(2,0)")
                .IsRequired();
            builder.Property(p => p.Partido)
                .HasColumnName("PARTIDO")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}