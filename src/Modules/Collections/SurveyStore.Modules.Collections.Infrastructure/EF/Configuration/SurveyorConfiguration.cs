using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class SurveyorConfiguration : IEntityTypeConfiguration<Surveyor>
    {
        public void Configure(EntityTypeBuilder<Surveyor> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(s => s.Value, s => new(s));
            builder.HasMany(s => s.Collections)
                .WithOne(c => c.Surveyor);
        }
    }
}
