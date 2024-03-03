using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SurveyStore.Modules.Stores.Api;
using SurveyStore.Shared.Abstractions.Modules;
using SurveyStore.Shared.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Bootstrapper
{
    public class Startup
    {
        private readonly IList<Assembly> _assemblies;
        private readonly IList<IModule> _modules;

        public Startup(IConfiguration configuration)
        {
            _assemblies = ModuleLoader.LoadAssemblies(configuration);
            _modules = ModuleLoader.LoadModules(_assemblies);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(_assemblies, _modules);
            foreach (var module in _modules)
            {
                module.Register(services);
            }
        }

        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseInfrastructure();
            foreach (var module in _modules)
            {
                module.Use(app);
            }
            logger.LogInformation($"Modules: {string.Join(", ", _modules.Select(m => m.Name))}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context
                    => context.Response.WriteAsync("SurveyStore API"));
            });
        }
    }
}
