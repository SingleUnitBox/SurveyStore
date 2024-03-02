using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Stores.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddStores(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }
    }
}
