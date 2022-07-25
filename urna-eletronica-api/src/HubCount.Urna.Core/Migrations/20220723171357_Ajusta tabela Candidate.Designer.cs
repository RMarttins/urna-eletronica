﻿// <auto-generated />
using System;
using HubCount.Urna.Core.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HubCount.Urna.Core.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20220723171357_Ajusta tabela Candidate")]
    partial class AjustatabelaCandidate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HubCount.Urna.Core.Models.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("CandidateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CANDIDATE_NAME");

                    b.Property<DateTime>("DtCreate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DT_CREATE");

                    b.Property<decimal>("Legenda")
                        .HasColumnType("DECIMAL(2,0)")
                        .HasColumnName("LEGENDA");

                    b.Property<string>("Partido")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("PARTIDO");

                    b.Property<string>("ViceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("VICE_NAME");

                    b.HasKey("Id");

                    b.ToTable("TB_CANDIDATE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CandidateName = "Canditato Teste 001",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3156),
                            Legenda = 10m,
                            Partido = "SOLID",
                            ViceName = "Vice Canditato Teste 001"
                        },
                        new
                        {
                            Id = 2,
                            CandidateName = "Canditato Teste 002",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3180),
                            Legenda = 20m,
                            Partido = "CQRS",
                            ViceName = "Vice Canditato Teste 002"
                        },
                        new
                        {
                            Id = 3,
                            CandidateName = "Canditato Teste 003",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3183),
                            Legenda = 30m,
                            Partido = "DDD",
                            ViceName = "Vice Canditato Teste 003"
                        },
                        new
                        {
                            Id = 4,
                            CandidateName = "Canditato Teste 004",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3186),
                            Legenda = 40m,
                            Partido = "TDD",
                            ViceName = "Vice Canditato Teste 004"
                        },
                        new
                        {
                            Id = 5,
                            CandidateName = "Canditato Teste 005",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3188),
                            Legenda = 50m,
                            Partido = "BDD",
                            ViceName = "Vice Canditato Teste 005"
                        },
                        new
                        {
                            Id = 6,
                            CandidateName = "Canditato Teste 006",
                            DtCreate = new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3190),
                            Legenda = 60m,
                            Partido = "GIT",
                            ViceName = "Vice Canditato Teste 006"
                        });
                });

            modelBuilder.Entity("HubCount.Urna.Core.Models.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("CANDIDATE_ID");

                    b.Property<DateTime>("DtVote")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DT_VOTE");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("TB_VOTE", (string)null);
                });

            modelBuilder.Entity("HubCount.Urna.Core.Models.Entities.Vote", b =>
                {
                    b.HasOne("HubCount.Urna.Core.Models.Entities.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("HubCount.Urna.Core.Models.Entities.Candidate", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}