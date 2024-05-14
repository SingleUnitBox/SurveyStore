using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Shared.Abstractions.Types;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Configuration
{
    public class KitConfiguration : IEntityTypeConfiguration<Kit>
    {
        public void Configure(EntityTypeBuilder<Kit> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id)
                .HasConversion(k => k.Value, k => new(k));
            builder.Property(k => k.Version)
                .IsConcurrencyToken();
            builder.HasDiscriminator<string>("Type")
                .HasValue<Tripod>(KitTypes.Tripod)
                .HasValue<DetailPole>(KitTypes.DetailPole);
                //.HasValue<GNSSPole>(nameof(GNSSPole))
                //.HasValue<TraversePrism>(KitTypes.TraversePrism);
            builder.HasIndex(k => k.SerialNumber)
                .IsUnique();
        }
    }
}
