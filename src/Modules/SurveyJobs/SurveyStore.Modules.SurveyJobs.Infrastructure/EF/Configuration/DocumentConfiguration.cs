using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasConversion(d => d.Value, d => new(d));
            builder.Property(d => d.DocumentType)
                .HasConversion(d => d.Name, d => DocumentType.Create(d));
            builder.HasOne(d => d.SurveyJob)
                .WithMany(sj => sj.Documents);
        }
    }
}
