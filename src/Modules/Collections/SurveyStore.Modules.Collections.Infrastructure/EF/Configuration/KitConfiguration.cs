using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Infrastructure.EF.Configuration.ValueConverters;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class KitConfiguration : IEntityTypeConfiguration<Kit>
    {
        public void Configure(EntityTypeBuilder<Kit> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id)
                .HasConversion(id => id.Value, value => new(value));
            builder.Property(k => k.Brand)
                .HasConversion(BrandValueConverter.ValueConverter);
            builder.Property(k => k.Model)
                .HasConversion(ModelValueConverter.ValueConverter);
            builder.Property(k => k.SerialNumber)
                .HasConversion(SerialNumberConverter.ValueConverter);
            builder.HasIndex(k => k.SerialNumber)
                .IsUnique();
            builder.Property(k => k.Type)
                .HasConversion(KitTypeValueConverter.ValueConverter);
            builder.Property(k => k.Id)
                .HasConversion(k => k.Value, k => new(k));
        }
    }
}
