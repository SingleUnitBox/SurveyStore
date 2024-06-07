using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.Middlewares
{
    public class SurveyJobsOuterLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<SurveyJobsOuterLoggingMiddleware> _logger;

        public SurveyJobsOuterLoggingMiddleware(ILogger<SurveyJobsOuterLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Executing delegate '{context.Request.Path}' from outer middleware in next step");           
            await next(context);
            _logger.LogInformation($"Success! Executed delegate '{context.Request.Path}' from outer middleware.");                    
        }
    }
}
