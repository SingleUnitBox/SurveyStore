using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Surveyors.Core.Entities;

namespace SurveyStore.Modules.Surveyors.Core.DAL
{
    public class SurveyorDbContext : DbContext
    {
        public DbSet<Surveyor> Surveyors { get; set; }
        public SurveyorDbContext(DbContextOptions<SurveyorDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("surveyors");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
