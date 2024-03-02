using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly IExceptionCompositionRoot _exceptionCompositionRoot;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger,
            IExceptionCompositionRoot exceptionCompositionRoot)
        {
            _logger = logger;
            _exceptionCompositionRoot = exceptionCompositionRoot;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(exception, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var exceptionResponse = _exceptionCompositionRoot.Map(exception);
            context.Response.StatusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
            var response = exceptionResponse?.Response;
            if (response is null)
            {
                return;
            }

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
