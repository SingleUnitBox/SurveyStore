using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.Middlewares
{
    public class SurveyJobsInnerLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<SurveyJobsInnerLoggingMiddleware> _logger;

        public SurveyJobsInnerLoggingMiddleware(ILogger<SurveyJobsInnerLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Executing delegate '{next.GetType().Name}' from inner middleware in next step");
            await next(context);
            _logger.LogInformation($"Success! Executed delegate '{next.GetType().Name}' from inner middleware.");
        }
    }
}
