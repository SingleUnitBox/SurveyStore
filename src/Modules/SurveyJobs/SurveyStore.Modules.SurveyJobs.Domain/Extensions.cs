﻿using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.SurveyJobs.Domain.DomainServices;
using SurveyStore.Modules.SurveyJobs.Domain.Policies;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Api")]
[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Tests.Unit")]

namespace SurveyStore.Modules.SurveyJobs.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddPolicies();
            services.AddDomainServices();

            return services;
        }
    }
}
