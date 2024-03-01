using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyStore.Modules.Stores.Core.Entities;
using System;

namespace SurveyStore.Modules.Stores.Core.DAL.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
