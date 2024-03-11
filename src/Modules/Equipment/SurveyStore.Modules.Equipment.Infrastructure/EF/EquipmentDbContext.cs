using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF
{
    public class EquipmentDbContext : DbContext
    {
        public DbSet<SurveyEquipment> SurveyEquipment { get; set; }
        public DbSet<Store> Stores { get; set; }
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
