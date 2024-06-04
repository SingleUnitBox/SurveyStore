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
        private readonly ICustomErrorMapper _customErrorMapper;

        public SurveyStoreCustomErrorHandlerMiddleware(ILogger<SurveyStoreCustomErrorHandlerMiddleware> logger,
            IExceptionCompositionRoot exceptionCompositionRoot,
            ICustomErrorMapper customErrorMapper)
        {
            _logger = logger;
            _exceptionCompositionRoot = exceptionCompositionRoot;
            _customErrorMapper = customErrorMapper;
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
                await HandleExceptionAsync(ex, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var exceptionResponse = _customErrorMapper.Map(exception);
            context.Response.StatusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
            //var response = exceptionResponse?.Response;
            //if (response is null)
            //{
            //    return;
            //}

            await context.Response.WriteAsJsonAsync(exceptionResponse);
        }
    }
}