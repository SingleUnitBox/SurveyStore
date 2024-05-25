﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    [DbContext(typeof(SurveyJobsDbContext))]
    partial class SurveyJobsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("surveyJobs")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("DocumentType")
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<Guid?>("SurveyJobId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SurveyJobId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.SurveyJob", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BriefIssued")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SurveyType")
                        .HasColumnType("text");

                    b.Property<Guid?>("SurveyorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SurveyorId");

                    b.ToTable("SurveyJobs");
                });

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.Surveyor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Surveyors");
                });

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.Document", b =>
                {
                    b.HasOne("SurveyStore.Modules.SurveyJobs.Domain.Entities.SurveyJob", "SurveyJob")
                        .WithMany("Documents")
                        .HasForeignKey("SurveyJobId");

                    b.Navigation("SurveyJob");
                });

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.SurveyJob", b =>
                {
                    b.HasOne("SurveyStore.Modules.SurveyJobs.Domain.Entities.Surveyor", "Surveyor")
                        .WithMany()
                        .HasForeignKey("SurveyorId");

                    b.Navigation("Surveyor");
                });

            modelBuilder.Entity("SurveyStore.Modules.SurveyJobs.Domain.Entities.SurveyJob", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
