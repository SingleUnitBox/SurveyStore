using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Calibrations.Domain.Exceptions
{
    public class EmptyCertificateNumberException : SurveyStoreException
    {
        public EmptyCertificateNumberException()
            : base("Certificate number is empty.")
        {
            
        }
    }
}
