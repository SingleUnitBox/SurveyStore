using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class KitConfiguration : IEntityTypeConfiguration<Kit>
    {
        public void Configure(EntityTypeBuilder<Kit> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id)
                .HasConversion(k => k.Value, k => new(k));
            builder.Property(k => k.StoreId)
                .HasConversion(k => k.Value, k => new(k));
            builder.Property(k => k.Version)
                .IsConcurrencyToken();
            builder.HasIndex(k => k.SerialNumber)
                .IsUnique();
            builder.HasOne(k => k.Store)
                .WithMany();
        }
    }
}
