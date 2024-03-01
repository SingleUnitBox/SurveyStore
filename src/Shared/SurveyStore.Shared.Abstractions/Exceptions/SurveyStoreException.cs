using System;

namespace SurveyStore.Shared.Abstractions.Exceptions
{
    public abstract class SurveyStoreException : Exception
    {
        public SurveyStoreException(string message) : base(message)
        {
        }
    }
}
