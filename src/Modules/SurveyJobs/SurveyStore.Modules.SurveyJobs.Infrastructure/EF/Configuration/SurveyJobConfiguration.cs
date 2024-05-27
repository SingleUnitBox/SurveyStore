using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration
{
    public class SurveyJobConfiguration : IEntityTypeConfiguration<SurveyJob>
    {
        public void Configure(EntityTypeBuilder<SurveyJob> builder)
        {
            builder.HasKey(sj => sj.Id);
            builder.Property(sj => sj.Id)
                .HasConversion(sj => sj.Value, sj => new(sj));
            builder.Property(sj => sj.Name)
                .HasConversion(n => n.Name, n => SurveyJobName.Create(n));
            builder.Property(sj => sj.SurveyType)
                .HasConversion(st => st.Value, st => SurveyType.Create(st));
            builder.Property(sj => sj.Budget)
                .HasConversion(sj => sj.Value, sj => new(sj));
            builder.HasMany(sj => sj.Surveyors)
                .WithMany(s => s.SurveyJobs);
            builder.HasMany(sj => sj.Documents)
                .WithOne(d => d.SurveyJob);
            builder.Property(sj => sj.Version)
                .IsConcurrencyToken();
        }
    }
}
