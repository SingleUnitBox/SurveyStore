using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Collections.Application.Exceptions
{
    public class ReturningOtherCollectionException : SurveyStoreException
    {
        public Guid CollectionId { get; }
        public Guid SurveyorId { get; }
        public ReturningOtherCollectionException(Guid collectionId, Guid surveyorId)
            : base($"Collection with id '{collectionId}' does not belong to surveyor with id '{surveyorId}'.")
        {
            CollectionId = collectionId;
            SurveyorId = surveyorId;
        }
    }
}
