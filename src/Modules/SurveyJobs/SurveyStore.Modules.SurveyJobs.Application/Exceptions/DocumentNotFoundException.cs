using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class DocumentNotFoundException : SurveyStoreException
    {
        public string Link { get; }
        public DocumentNotFoundException(string link)
            : base($"Document under link of '{link}' was not found.")
        {
            Link = link;
        }
    }
}
