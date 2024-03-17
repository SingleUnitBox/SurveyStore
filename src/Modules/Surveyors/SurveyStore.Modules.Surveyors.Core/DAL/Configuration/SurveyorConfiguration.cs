using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Surveyors.Core.Entities;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Configuration
{
    public class SurveyorConfiguration : IEntityTypeConfiguration<Surveyor>
    {
        public void Configure(EntityTypeBuilder<Surveyor> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
