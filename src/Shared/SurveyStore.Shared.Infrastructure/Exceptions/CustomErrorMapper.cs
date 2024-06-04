using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Net;
using static SurveyStore.Shared.Infrastructure.Exceptions.ExceptionToResponseMapper;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public class CustomErrorMapper : ICustomErrorMapper
    {
        public ExceptionResponse Map(Exception exception)
        {
            var exceptionResponse = exception switch
            {
                SurveyStoreException => new ExceptionResponse(new ErrorsResponse(
                    new Error(exception.GetType().Name, exception.Message)), HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new Error("error", "there was an error"), HttpStatusCode.InternalServerError)
            };

            return exceptionResponse;
        }
    }
}
