using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration.ValueConverters;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration
{
    public class SurveyJobConfiguration : IEntityTypeConfiguration<SurveyJob>
    {
        public void Configure(EntityTypeBuilder<SurveyJob> builder)
        {
            builder.HasKey(sj => sj.Id);
            builder.Property(sj => sj.Id)
                .HasConversion(sj => sj.Value, sj => new(sj));

            //builder.Property(sj => sj.Name)
            //    .HasConversion(n => n.Name, n => SurveyJobName.Create(n));
            var surveyJobNameConverter = new ValueConverter<SurveyJobName, string>(x => x.Name,
                x => SurveyJobName.Create(x));
            builder.Property(typeof(SurveyJobName), "Name")
                .HasConversion(SurveyJobNameConverter.ValueConverter);

            builder.Property(sj => sj.SurveyType)
                .HasConversion(st => st.Value, st => SurveyType.Create(st));
            builder.Property(sj => sj.Budget)
                .HasConversion(b => b.Value, b => new(b));
            builder.Property(sj => sj.CostToDeliver)
                .HasConversion(c => c.Value, c => new(c));
            builder.HasMany(sj => sj.Surveyors)
                .WithMany(s => s.SurveyJobs);
            builder.HasMany(sj => sj.Documents)
                .WithOne(d => d.SurveyJob);
            builder.Property(sj => sj.Version)
                .IsConcurrencyToken();

            builder.HasIndex(sj => new { sj.Name, sj.BriefIssued })
                .IsUnique();
        }
    }
}
