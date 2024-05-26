using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class SurveyJobAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public SurveyJobAlreadyExistsException(Guid id) 
            : base($"Survey job with '{id}' already exists.")
        {
            Id = id;
        }
    }
}