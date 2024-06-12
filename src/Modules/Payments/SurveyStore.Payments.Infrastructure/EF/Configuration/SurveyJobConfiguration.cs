using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Payments.Domain.Entities;
using SurveyStore.Modules.Payments.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Payments.Infrastructure.EF.Configuration
{
    public class SurveyJobConfiguration : IEntityTypeConfiguration<SurveyJob>
    {
        public void Configure(EntityTypeBuilder<SurveyJob> builder)
        {
            builder.HasKey(sj => sj.Id);
            builder.Property(sj => sj.Id)
                .HasConversion(id => id.Value, id => new AggregateId(id));
            builder.Property(sj => sj.Name)
                .HasConversion(n => n.Value, n => new SurveyJobName(n));
            builder.Property(sj => sj.IssuedAt)
                .HasConversion(i => i.Value, i => new Date(i));
            builder.Property(sj => sj.Budget)
                .HasConversion(b => b.Value, b => new Money(b));
            builder.Property(sj => sj.CostToDeliver)
                .HasConversion(c => c.Value, c => new Money(c));
            builder.Property(sj => sj.Version)
                .IsConcurrencyToken();
        }
    }
}
