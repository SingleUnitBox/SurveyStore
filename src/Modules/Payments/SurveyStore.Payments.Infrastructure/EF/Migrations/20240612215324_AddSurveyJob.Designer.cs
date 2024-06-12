﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.Payments.Infrastructure.EF;

namespace SurveyStore.Modules.Payments.Infrastructure.EF.Migrations
{
    [DbContext(typeof(PaymentsDbContext))]
    [Migration("20240612215324_AddSurveyJob")]
    partial class AddSurveyJob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("payments")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyStore.Modules.Payments.Domain.Entities.SurveyJob", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int?>("Budget")
                        .HasColumnType("integer");

                    b.Property<int?>("CostToDeliver")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IssuedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SurveyJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
