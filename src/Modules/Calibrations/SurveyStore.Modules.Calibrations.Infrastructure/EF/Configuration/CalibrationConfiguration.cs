using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Calibrations.Domain.Entities;

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
        }
    }
}
