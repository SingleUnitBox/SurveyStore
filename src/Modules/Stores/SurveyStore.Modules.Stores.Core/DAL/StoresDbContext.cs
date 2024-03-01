using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Stores.Core.Entities;

namespace SurveyStore.Modules.Stores.Core.DAL
{
    public class StoresDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public StoresDbContext(DbContextOptions<StoresDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("stores");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
