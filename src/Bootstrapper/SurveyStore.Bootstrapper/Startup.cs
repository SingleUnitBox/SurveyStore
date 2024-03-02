using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SurveyStore.Modules.Stores.Api;
using SurveyStore.Modules.Stores.Core;
using SurveyStore.Shared.Infrastructure;

namespace SurveyStore.Bootstrapper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStores();
            services.AddInfrastructure();       
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseInfrastructure();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context
                    => context.Response.WriteAsync("SurveyStore API"));
            });
        }
    }
}
