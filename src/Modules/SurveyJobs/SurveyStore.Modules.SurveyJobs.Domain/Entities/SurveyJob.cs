using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        public SurveyJobName Name { get; private set; }
        public DateTime BriefIssued { get; private set; }
        public DateTime DueDate { get; private set; }
        public Money Budget { get; private set; }
        public SurveyType SurveyType { get; private set; }
        public IEnumerable<Surveyor> Surveyors => _surveyors;
        private readonly List<Surveyor> _surveyors = new List<Surveyor>();
        public IEnumerable<Document> Documents => _documents;
        private readonly List<Document> _documents = new List<Document>();

        private SurveyJob()
        {
            
        }
        private SurveyJob(Guid id)
        {
            Id = id;
        }

        public void ChangeSurveyJobName(string name)
        {
            Name = SurveyJobName.Create(name);
        }

        public void ChangeBriefIssued(DateTime briefIssued)
        {
            BriefIssued = briefIssued;
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
        }

        public void SetBudget(int value)
        {
            Budget = new Money(value);
        }

        public void ChangeSurveyType(string surveyType)
        {
            SurveyType = SurveyType.Create(surveyType);
        }

        public void AddSurveyor(Surveyor surveyor)
        {
            _surveyors.Add(surveyor);
        }

        public void AddDocument(Document document)
        {
            _documents.Add(document);
        }

        public static SurveyJob Create(Guid id, string name, DateTime briefIssued,
            DateTime dueDate, string surveyType, int? value)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeSurveyJobName(name);
            surveyJob.ChangeBriefIssued(briefIssued);
            surveyJob.ChangeDueDate(dueDate);
            surveyJob.ChangeSurveyType(surveyType);
            if (value.HasValue)
            {
                surveyJob.SetBudget(value.Value);
            }

            return surveyJob;
        }
    }
}
