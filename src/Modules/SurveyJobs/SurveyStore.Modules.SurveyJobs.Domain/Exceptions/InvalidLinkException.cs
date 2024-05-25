using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidLinkException : SurveyStoreException
    {
        public string Link { get; }
        public InvalidLinkException(string link)
            : base($"Link '{link}' is invalid.")
        {
            Link = link;
        }
    }
}
