using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Equipment.Application.Types;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Configuration
{
    public class SurveyEquipmentConfiguration : IEntityTypeConfiguration<SurveyEquipment>
    {
        public void Configure(EntityTypeBuilder<SurveyEquipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SerialNumber)
                .IsConcurrencyToken();
            builder.HasDiscriminator<string>("Type")
                .HasValue<TotalStation>(SurveyEquipmentTypes.TotalStation)
                .HasValue<GNSS>(SurveyEquipmentTypes.GNSS)
                .HasValue<FieldController>(SurveyEquipmentTypes.FieldController)
                .HasValue<GroundPenetratingRadar>(SurveyEquipmentTypes.GroundPenetratingRadar)
                .HasValue<CableAvoidanceTool>(SurveyEquipmentTypes.CAT);
        }
    }
}
