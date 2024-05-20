﻿using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Collections.Tests.Unit")]
namespace SurveyStore.Modules.Collections.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<ICollectionService, CollectionService>();
            services.AddSingleton<IKitCollectionPolicy, KitCollectionPolicy>();
            services.AddSingleton<ICollectionPolicy, CollectionPolicy>();

            return services;
        }
    }
}
