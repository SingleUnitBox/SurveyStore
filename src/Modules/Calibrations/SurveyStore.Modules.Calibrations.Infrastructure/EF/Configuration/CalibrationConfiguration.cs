using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.ValueObjects;
using System;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Configuration
{
    public class CalibrationConfiguration : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.SurveyEquipmentId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.Version)
                .IsConcurrencyToken();
            builder.Property(c => c.CalibrationDueDate)
                .HasConversion(c => c.Value, value => new(value));
            builder.Property(c => c.CertificateNumber)
                .HasConversion(c => c.Value, value => new CertificateNumber(value));
            builder.Property(c => c.CalibrationStatus)
                .HasConversion(c => c.Value, value => new(value));
        }
    }
}
