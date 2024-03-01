using System.Net;

namespace SurveyStore.Shared.Infrastructure.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
