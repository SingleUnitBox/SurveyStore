﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using System;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration
{
    public class SurveyJobConfiguration : IEntityTypeConfiguration<SurveyJob>
    {
        public void Configure(EntityTypeBuilder<SurveyJob> builder)
        {
            builder.HasKey(sj => sj.Id);
            builder.Property(sj => sj.Id)
                .HasConversion(sj => sj.Value, sj => new(sj));
            builder.HasOne(sj => sj.Surveyor);
            builder.HasMany(sj => sj.Documents)
                .WithOne(d => d.SurveyJob);
            builder.Property(sj => sj.Version)
                .IsConcurrencyToken();
        }
    }
}