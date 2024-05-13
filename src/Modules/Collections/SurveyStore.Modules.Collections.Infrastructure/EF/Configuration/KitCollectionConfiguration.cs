using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using System;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class KitCollectionConfiguration : IEntityTypeConfiguration<KitCollection>
    {
        public void Configure(EntityTypeBuilder<KitCollection> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.CollectionStoreId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.ReturnStoreId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.Version)
                .IsConcurrencyToken();
            builder.Property(c => c.KitId)
                .HasConversion(c => c.Value, c => new(c));
            builder.HasOne(c => c.Surveyor)
                .WithMany(s => s.KitCollections);
        }
    }
}
