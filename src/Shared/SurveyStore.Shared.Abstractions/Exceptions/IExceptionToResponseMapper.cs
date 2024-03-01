using System;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}
