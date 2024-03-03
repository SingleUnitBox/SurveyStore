using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    internal interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
