using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration
{
    public class SurveyorConfiguration : IEntityTypeConfiguration<Surveyor>
    {
        public void Configure(EntityTypeBuilder<Surveyor> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(s => s.Value, s => new(s));
            builder.Property(s => s.Version)
                .IsConcurrencyToken();
        }
    }
}
