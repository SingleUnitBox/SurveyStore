using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;
using static SurveyStore.Shared.Infrastructure.Exceptions.ExceptionToResponseMapper;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    internal class SurveyStoreCustomErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<SurveyStoreCustomErrorHandlerMiddleware> _logger;
        private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

        public SurveyStoreCustomErrorHandlerMiddleware(ILogger<SurveyStoreCustomErrorHandlerMiddleware> logger,
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
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message, "this is custom error");
                var result = _exceptionCompositionRoot.Map(ex);
                await context.Response.WriteAsJsonAsync(HandleExceptionAsync(ex, context));
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var (statusCode, error) = exception switch
            {
                SurveyStoreException => (StatusCodes.Status400BadRequest, exception.Message),
                _ => (StatusCodes.Status500InternalServerError, "There was an error")
            };

            var response = new ExceptionResponse(new ErrorsResponse(new Error(statusCode.ToString(), error)), (HttpStatusCode)statusCode);
            await Task.FromResult(response);
        }
    }
}