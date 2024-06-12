using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Payments.Domain.Entities;

namespace SurveyStore.Modules.Payments.Infrastructure.EF
{
    public class PaymentsDbContext : DbContext
    {
        public DbSet<SurveyJob> SurveyJobs { get; set; }
        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> dbOptions)
            : base(dbOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("payments");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
