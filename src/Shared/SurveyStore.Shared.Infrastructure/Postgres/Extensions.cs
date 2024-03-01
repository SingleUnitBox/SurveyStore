using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
