using SurveyStore.Modules.Payments.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Payments.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        private readonly SurveyJobName _name;
        public SurveyJobName Name { get; private set; }
        public DateTime IssuedAt { get; private set; }
        public int Budget { get; private set; }
        public int CostToDeliver { get; private set; }

        private SurveyJob()
        {
            
        }

        public SurveyJob(Guid id)
        {
            Id = id;
        }

        public void ChangeSurveyJobName(string name)
        {
            Name = new SurveyJobName(name);
            IncrementVersion();
        }

        public static SurveyJob Create(Guid id, string name)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeSurveyJobName(name);

            surveyJob.ClearEvents();
            surveyJob.Version = 0;

            return surveyJob;
        }
    }
}