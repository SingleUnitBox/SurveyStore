using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Exceptions
{
    public class SurveyorNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public string Email { get; }

        public SurveyorNotFoundException(Guid id)
            : base($"Surveyor with id '{id}' was not found.")
        {
            Id = id;
        }

        public SurveyorNotFoundException(string email)
            : base($"Surveyor with id '{email}' was not found.")
        {
            Email = email;
        }
    }
}
