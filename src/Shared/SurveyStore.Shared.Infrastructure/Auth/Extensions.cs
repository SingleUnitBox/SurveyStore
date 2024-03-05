using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Auth
{
    public static class Extensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IList<IModule> modules,
            Action<JwtBearerOptions> optionsFactory = null)
        {
            var options = services.GetOptions<AuthOptions>("auth");
            services.AddSingleton<IAuthManager, AuthManager>();
            if (options.AuthenticationDisabled)
            {
                services.AddSingleton<IPolicyEvaluator, DisabledAuthenticationPolicyEvaluator>();
            }

            return services;
        }
    }
}
