using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class DocumentAlreadyExistsException : SurveyStoreException
    {
        public string Link { get; }
        public DocumentAlreadyExistsException(string link)
            : base($"Document under link of '{link}' already exists.")
        {
            Link = link;
        }
    }
}
