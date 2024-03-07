using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using SurveyStore.Modules.Users.Core;

namespace SurveyStore.Modules.Users.Api
{
    public class UsersModule : IModule
    {
        public const string BasePath = "users-module";
        public string Name { get; } = "Users";

        public string Path => BasePath;
        public IEnumerable<string> Policies = new[]
        {
            "users"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
            
        }
    }
}
