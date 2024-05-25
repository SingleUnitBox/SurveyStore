using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.SurveyJobs.Domain.Exceptions
{
    public class InvalidDocumentTypeException : SurveyStoreException
    {
        public string DocumentType { get; }
        public InvalidDocumentTypeException(string documentType)
            : base($"Document type of '{documentType}' is invalid.")
        {
            DocumentType = documentType;
        }
    }
}
