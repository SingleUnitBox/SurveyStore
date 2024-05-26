using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        public IEnumerable<Surveyor> Surveyors => _surveyors;
        private readonly List<Surveyor> _surveyors = new List<Surveyor>();
        public DateTime BriefIssued { get; private set; }
        public DateTime DueDate { get; private set; }
        public SurveyType SurveyType { get; private set; }
        public IEnumerable<Document> Documents => _documents;
        private readonly List<Document> _documents = new List<Document>();

        private SurveyJob()
        {
            
        }
        private SurveyJob(Guid id)
        {
            Id = id;
        }

        public void AddSurveyor(Surveyor surveyor)
        {
            _surveyors.Add(surveyor);
        }

        public void ChangeBriefIssued(DateTime briefIssued)
        {
            BriefIssued = briefIssued;
        }

        public void ChangeDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
        }

        public void ChangeSurveyType(string surveyType)
        {
            SurveyType = SurveyType.Create(surveyType);
        }

        public void AddDocument(Document document)
        {
            _documents.Add(document);
        }

        public static SurveyJob Create(Guid id, DateTime briefIssued, DateTime dueDate, string surveyType)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeBriefIssued(briefIssued);
            surveyJob.ChangeDueDate(dueDate);
            surveyJob.ChangeSurveyType(surveyType);

            return surveyJob;
        }
    }
}
