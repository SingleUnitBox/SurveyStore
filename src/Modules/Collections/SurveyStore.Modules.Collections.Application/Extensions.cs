using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Application.Decorators.Events;
using SurveyStore.Modules.Collections.Application.Events.External;
using SurveyStore.Modules.Collections.Application.Events.External.Handlers;
using SurveyStore.Modules.Collections.Application.Policies;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Collections.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IEventMapper, EventMapper>();
            services.AddSingleton<IFreeCollectionRemovalPolicy, FreeCollectionRemovalPolicy>();

            //services.Decorate<IEventHandler<KitCreated>, KitCreatedHandlerDecorator>();
            services.Decorate(typeof(IEventHandler<>), typeof(EventHandlerDecorator<>));

            return services;
        }
    }
}
