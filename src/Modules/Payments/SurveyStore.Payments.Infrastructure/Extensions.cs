using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Payments.Domain.Repositories;
using SurveyStore.Modules.Payments.Infrastructure.Clients;
using SurveyStore.Modules.Payments.Infrastructure.EF;
using SurveyStore.Modules.Payments.Infrastructure.EF.Repositories;
using SurveyStore.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Payments.Api")]

namespace SurveyStore.Modules.Payments.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddApiClients();
            services.AddScoped<ISurveyJobRepository, PostgresSurveyJobRepository>();
            services.AddPostgres<PaymentsDbContext>();

            return services;
        }
    }
}
