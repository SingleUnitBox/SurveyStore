using Microsoft.EntityFrameworkCore;
using SurveyStore.Services.Stores.Core.Entities;

namespace SurveyStore.Services.Stores.Core.DAL
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
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
