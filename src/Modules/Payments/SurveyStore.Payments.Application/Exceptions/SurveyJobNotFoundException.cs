using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Payments.Application.Exceptions
{
    public class SurveyJobNotFoundException : SurveyStoreException
    {
        public Guid Id { get; set; }
        public SurveyJobNotFoundException(Guid id)
            : base($"Survey job with '{id}' was not found.")
        {
            Id = id;
        }
    }
}
