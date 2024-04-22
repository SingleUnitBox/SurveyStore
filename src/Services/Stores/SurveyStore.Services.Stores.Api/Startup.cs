using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SurveyStore.Services.Stores.Core;
using SurveyStore.Services.Stores.Core.DAL.Queries;
using SurveyStore.Services.Stores.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using SurveyStore.Shared.Infrastructure.Modules;

namespace SurveyStore.Services.Stores.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseModuleRequests()
            //    .Subscribe<GetStoreById, StoreDto>("stores/get",
            //        (query, sp) => sp.GetRequiredService<IQueryDispatcher>().QueryAsync(query));

            app.UseConvey();
            app.UseRabbitMq();
        }
    }
}
