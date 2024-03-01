using Humanizer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> Codes = new();
        public ExceptionResponse Map(Exception exception)
        {
            throw new NotImplementedException();
        }

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            var code = type.Name.Replace("Exception", string.Empty).Underscore();

            return Codes.GetOrAdd(exception.GetType(), code);
        }

        private record Error(string Code, string Message);
        private record ErrorsResponse(params Error[] Errors);
    }

    
}
