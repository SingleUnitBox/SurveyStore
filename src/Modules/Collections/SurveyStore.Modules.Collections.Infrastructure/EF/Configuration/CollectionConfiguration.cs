﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.Version)
                .IsConcurrencyToken();
            builder.Property(c => c.CollectionStoreId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.ReturnStoreId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.SurveyEquipmentId)
                .HasConversion(c => c.Value, c => new(c));
            builder.Property(c => c.CollectedAt)
                .HasConversion(c => c.Value, value => new Date(value));
            builder.Property(c => c.ReturnedAt)
                .HasConversion(c => c.Value, value => new Date(value));
        }
    }
}
