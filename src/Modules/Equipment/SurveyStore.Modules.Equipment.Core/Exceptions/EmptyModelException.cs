using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Core.Exceptions
{
    public class EmptyModelException : SurveyStoreException
    {
        public EmptyModelException()
            : base($"Survey equipment model is empty.")
        {
        }
    }
}