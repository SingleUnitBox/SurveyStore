using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Configuration
{
    public class SurveyEquipmentConfiguration : IEntityTypeConfiguration<SurveyEquipment>
    {
        public void Configure(EntityTypeBuilder<SurveyEquipment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(s => s.Value, s => new(s));
            builder.Property(s => s.StoreId)
                .HasConversion(s => s.Value, s => new(s));
        }
    }
}
