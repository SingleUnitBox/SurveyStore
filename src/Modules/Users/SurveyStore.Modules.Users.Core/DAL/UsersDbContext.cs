using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Users.Core.Entities;

namespace SurveyStore.Modules.Users.Core.DAL
{
    internal sealed class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("users");
        }
    }
}
