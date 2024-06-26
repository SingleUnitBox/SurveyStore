﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    [DbContext(typeof(SurveyJobsDbContext))]
    [Migration("20240608115041_EditSurveyJobConfiguration3")]
    partial class EditSurveyJobConfiguration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("surveyJobs")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyJobSurveyor", b =>
                {
                    b.Property<Guid>("SurveyJobsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveyorsId")
                        .HasColumnType("uuid");

                    b.HasKey("SurveyJobsId", "SurveyorsId");

                    b.HasIndex("SurveyorsId");

                    b.ToTable("SurveyJobSurveyor");
                });

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

                    b.Property<int?>("Budget")
                        .HasColumnType("integer");

                    b.Property<int?>("CostToDeliver")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name2");

                    b.Property<string>("SurveyType")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

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

            modelBuilder.Entity("SurveyJobSurveyor", b =>
                {
                    b.HasOne("SurveyStore.Modules.SurveyJobs.Domain.Entities.SurveyJob", null)
                        .WithMany()
                        .HasForeignKey("SurveyJobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveyStore.Modules.SurveyJobs.Domain.Entities.Surveyor", null)
                        .WithMany()
                        .HasForeignKey("SurveyorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
