using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Configuration
{
    public class SurveyorConfiguration : IEntityTypeConfiguration<Surveyor>
    {
        public void Configure(EntityTypeBuilder<Surveyor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new SurveyorId(x));
        }
    }
}
