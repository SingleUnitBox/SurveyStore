using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Calibrations.Domain.Entities;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Configuration
{
    public class SurveyEquipmentConfiguration : IEntityTypeConfiguration<SurveyEquipment>
    {
        public void Configure(EntityTypeBuilder<SurveyEquipment> builder)
        {
            builder.HasKey(se => se.Id);
            builder.Property(se => se.Id)
                .HasConversion(se => se.Value, se => new(se));
            builder.HasIndex(se => se.SerialNumber)
                .IsUnique();
        }
    }
}
