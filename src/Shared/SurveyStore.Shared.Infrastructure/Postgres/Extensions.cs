using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SurveyStore.Shared.Infrastructure.Postgres
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            var options = services.GetOptions<PostgresOptions>("postgres");
            services.AddSingleton(options);

            return services;
        }

        public static IServiceCollection AddPostgres<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var postgresOptions = services.GetOptions<PostgresOptions>("postgres");
            services.AddDbContext<TDbContext>(x =>
            {
                x.UseNpgsql(postgresOptions.ConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork<TUnitOfWork, TImplementation>(this IServiceCollection services)
            where TUnitOfWork : class, IUnitOfWork where TImplementation : class, TUnitOfWork
        {
            services.AddScoped<TUnitOfWork, TImplementation>();
            services.AddScoped<IUnitOfWork, TImplementation>();

            return services;
        }
    }
}
