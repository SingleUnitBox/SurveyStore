using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Domain.Entities;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF
{
    internal class CalibrationsDbContext : DbContext 
    {
        public DbSet<SurveyEquipment> SurveyEquipment { get; set; }
        public DbSet<Calibration> Calibrations { get; set; }
        public CalibrationsDbContext(DbContextOptions<CalibrationsDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("calibrations");
        }
    }
}
