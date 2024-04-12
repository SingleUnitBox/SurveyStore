﻿using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Application.Clients.Stores;
using SurveyStore.Modules.Collections.Application.Clients.Surveyors;

namespace SurveyStore.Modules.Collections.Infrastructure.Clients
{
    internal static class Extensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services.AddSingleton<ISurveyorsApiClient, SurveyorsApiClient>();
            services.AddSingleton<IStoresApiClient, StoresApiClient>();

            return services;
        }
    }
}