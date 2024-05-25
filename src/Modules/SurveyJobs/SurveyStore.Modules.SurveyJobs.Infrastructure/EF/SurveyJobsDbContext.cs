using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF
{
    internal sealed class SurveyJobsDbContext : DbContext
    {
        public DbSet<SurveyJob> SurveyJobs { get; set; }
        public DbSet<Surveyor> Surveyors { get; set; }
        public DbSet<Document> Documents { get; set; }

        public SurveyJobsDbContext(DbContextOptions<SurveyJobsDbContext> options)
            : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("surveyJobs");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
