using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public class SurveyStoreCustomErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<SurveyStoreCustomErrorHandlerMiddleware> _logger;

        public SurveyStoreCustomErrorHandlerMiddleware(ILogger<SurveyStoreCustomErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
