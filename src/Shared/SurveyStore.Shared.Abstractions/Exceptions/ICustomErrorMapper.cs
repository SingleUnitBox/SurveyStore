using System;

namespace SurveyStore.Shared.Abstractions.Exceptions
{
    public interface ICustomErrorMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}