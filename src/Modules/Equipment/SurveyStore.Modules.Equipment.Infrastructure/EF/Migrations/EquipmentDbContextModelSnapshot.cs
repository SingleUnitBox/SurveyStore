﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.Equipment.Infrastructure.EF;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    [DbContext(typeof(EquipmentDbContext))]
    partial class EquipmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("equipment")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CalibrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan?>("CalibrationInterval")
                        .HasColumnType("interval");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<DateTime>("PurchasedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("text");

                    b.Property<Guid?>("StoreId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SurveyorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("SurveyorId");

                    b.ToTable("SurveyEquipment");

                    b.HasDiscriminator<string>("Type").HasValue("SurveyEquipment");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.Surveyor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Surveyors");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.CableAvoidanceTool", b =>
                {
                    b.HasBaseType("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment");

                    b.HasDiscriminator().HasValue("cable avoidance tool");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.FieldController", b =>
                {
                    b.HasBaseType("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment");

                    b.Property<int>("ScreenSize")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("field controller");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.GNSS", b =>
                {
                    b.HasBaseType("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("gnss");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.GroundPenetratingRadar", b =>
                {
                    b.HasBaseType("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment");

                    b.Property<decimal>("Frequency")
                        .HasColumnType("numeric");

                    b.Property<bool>("OffRoadMode")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("ground penetrating radar");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.TotalStation", b =>
                {
                    b.HasBaseType("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment");

                    b.Property<decimal>("Accuracy")
                        .HasColumnType("numeric");

                    b.Property<int>("MaxRemoteDistance")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("total station");
                });

            modelBuilder.Entity("SurveyStore.Modules.Equipment.Core.Entities.SurveyEquipment", b =>
                {
                    b.HasOne("SurveyStore.Modules.Equipment.Core.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");

                    b.HasOne("SurveyStore.Modules.Equipment.Core.Entities.Surveyor", "Surveyor")
                        .WithMany()
                        .HasForeignKey("SurveyorId");

                    b.Navigation("Store");

                    b.Navigation("Surveyor");
                });
#pragma warning restore 612, 618
        }
    }
}
