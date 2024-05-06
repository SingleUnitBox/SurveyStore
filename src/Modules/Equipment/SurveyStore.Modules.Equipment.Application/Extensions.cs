using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Equipment.Api")]
namespace SurveyStore.Modules.Equipment.Application
{
    internal static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IEventMapper, EventMapper>();

            return services;
        }
    }
}
