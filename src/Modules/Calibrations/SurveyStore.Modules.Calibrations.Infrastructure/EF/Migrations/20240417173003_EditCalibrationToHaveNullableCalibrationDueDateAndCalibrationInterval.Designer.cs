﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyStore.Modules.Calibrations.Infrastructure.EF;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    [DbContext(typeof(CalibrationsDbContext))]
    [Migration("20240417173003_EditCalibrationToHaveNullableCalibrationDueDateAndCalibrationInterval")]
    partial class EditCalibrationToHaveNullableCalibrationDueDateAndCalibrationInterval
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("calibrations")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SurveyStore.Modules.Calibrations.Domain.Entities.Calibration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CalibrationDueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan?>("CalibrationInterval")
                        .HasColumnType("interval");

                    b.Property<string>("CalibrationStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CertificateNumber")
                        .HasColumnType("text");

                    b.Property<Guid?>("SurveyEquipmentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SurveyEquipmentId");

                    b.ToTable("Calibrations");
                });

            modelBuilder.Entity("SurveyStore.Modules.Calibrations.Domain.Entities.SurveyEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("SurveyEquipment");
                });

            modelBuilder.Entity("SurveyStore.Modules.Calibrations.Domain.Entities.Calibration", b =>
                {
                    b.HasOne("SurveyStore.Modules.Calibrations.Domain.Entities.SurveyEquipment", "SurveyEquipment")
                        .WithMany()
                        .HasForeignKey("SurveyEquipmentId");

                    b.Navigation("SurveyEquipment");
                });
#pragma warning restore 612, 618
        }
    }
}
