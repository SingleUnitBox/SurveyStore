using SurveyStore.Modules.Payments.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Payments.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        private readonly SurveyJobName _name;
        public SurveyJobName Name { get; private set; }
        public Date IssuedAt { get; private set; }
        public Money Budget { get; private set; }
        public Money CostToDeliver { get; private set; }

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

        public void ChangeIssuedAt(DateTime date)
        {
            IssuedAt = date;
            IncrementVersion();
        }

        public void SetBudget(int budget)
        {
            Budget = budget;
            IncrementVersion();
        }

        public void ChangeCostToDeliver(int costToDeliver)
        {
            CostToDeliver = costToDeliver;
            IncrementVersion();
        }

        public static SurveyJob Create(Guid id, string name, DateTime issuedAt, int budget, int costToDeliver)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeSurveyJobName(name);
            surveyJob.ChangeIssuedAt(issuedAt);
            surveyJob.SetBudget(budget);
            surveyJob.ChangeCostToDeliver(costToDeliver);

            surveyJob.ClearEvents();
            surveyJob.Version = 0;

            return surveyJob;
        }
    }
}