using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Domain.Kit.Entities;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF
{
    public class EquipmentDbContext : DbContext
    {
        public DbSet<SurveyEquipment> SurveyEquipment { get; set; }
        public DbSet<Kit> Kit { get; set; }
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("equipment");
        }
    }
}
