using Humanizer;
using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> Codes = new();
        private record Error(string Code, string Message);
        private record ErrorsResponse(params Error[] Errors);

        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                SurveyStoreException => new(new ErrorsResponse(
                    new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.BadRequest),
                _ => new(new ErrorsResponse(
                    new Error("error", "There was an error.")), HttpStatusCode.InternalServerError)
            };

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            var code = type.Name.Replace("Exception", string.Empty).Underscore();

            return Codes.GetOrAdd(exception.GetType(), code);
        }
    }

    
}
