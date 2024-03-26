﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.Collections.Infrastructure.EF;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    [DbContext(typeof(CollectionsDbContext))]
    [Migration("20240326223058_EditConfiguration")]
    partial class EditConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("collections")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CollectedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CollectionStoreId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReturnStoreId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ReturnedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("SurveyEquipmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SurveyorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SurveyorId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.SurveyEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("text");

                    b.Property<Guid?>("StoreId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("SurveyEquipment");
                });

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.Surveyor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Surveyors");
                });

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.Collection", b =>
                {
                    b.HasOne("SurveyStore.Modules.Collections.Core.Entities.Surveyor", "Surveyor")
                        .WithMany("Collections")
                        .HasForeignKey("SurveyorId");

                    b.Navigation("Surveyor");
                });

            modelBuilder.Entity("SurveyStore.Modules.Collections.Core.Entities.Surveyor", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
