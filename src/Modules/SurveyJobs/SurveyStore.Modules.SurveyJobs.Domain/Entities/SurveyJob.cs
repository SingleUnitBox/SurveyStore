using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        private string _name;
        //public SurveyJobName Name { get; private set; }
        public Date BriefIssued { get; private set; }
        public Date DueDate { get; private set; }
        public Date IssuedAt { get; private set; }
        public SurveyType SurveyType { get; private set; }
        public Money Budget { get; private set; }
        public Money CostToDeliver { get; private set; }        
        public IEnumerable<Surveyor> Surveyors => _surveyors;
        private readonly List<Surveyor> _surveyors = new List<Surveyor>();
        public IEnumerable<Document> Documents => _documents;
        private readonly List<Document> _documents = new List<Document>();

        public SurveyJob()
        {
            
        }

        private SurveyJob(Guid id)
        {
            Id = id;
        }

        //private SurveyJob(Guid id, string name, DateTime briefIssued,
        //    DateTime dueDate, string surveyType, int budget) : this(id)
        //{
        //    _name = name;
        //    BriefIssued = briefIssued;
        //    DueDate = dueDate;
        //    SurveyType = surveyType;
        //    Budget = budget;
        //}

        public void ChangeSurveyJobName(string name)
        {
            _name = SurveyJobName.Create(name);
            IncrementVersion();
        }

        public void ChangeBriefIssued(DateTime briefIssued)
        {
            BriefIssued = briefIssued;
            IncrementVersion();
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
            IncrementVersion();
        }
         
        public void ChangeIssuedAt(DateTime issuedAt)
        {
            IssuedAt = issuedAt;
            IncrementVersion();
        }

        public void SetBudget(int value)
        {
            Budget = new Money(value);
            IncrementVersion();
        }

        public void ChangeCostToDeliver(int cost)
        {
            CostToDeliver = new Money(cost);
            IncrementVersion();
        }

        public void ChangeSurveyType(string surveyType)
        {
            SurveyType = SurveyType.Create(surveyType);
            IncrementVersion();
        }

        internal void AddSurveyor(Surveyor surveyor)
        {
            _surveyors.Add(surveyor);
            IncrementVersion();
        }

        public void AddDocument(Document document)
        {
            _documents.Add(document);
            IncrementVersion();
        }

        public static SurveyJob Create(Guid id, string name, DateTime briefIssued,
            DateTime dueDate, string surveyType, int? budget, int? costToDeliver)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeSurveyJobName(name);
            surveyJob.ChangeBriefIssued(briefIssued);
            surveyJob.ChangeDueDate(dueDate);
            surveyJob.ChangeSurveyType(surveyType);
            if (budget.HasValue)
            {
                surveyJob.SetBudget(budget.Value);
            }

            if (costToDeliver.HasValue)
            {
                surveyJob.ChangeCostToDeliver(costToDeliver.Value);
            }

            surveyJob.Version = 0;
            surveyJob.ClearEvents();

            return surveyJob;
        }
    }
}