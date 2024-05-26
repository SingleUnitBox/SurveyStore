using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        public Surveyor Surveyor { get; private set; }
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

        public void ChangeSurveyor(Surveyor surveyor)
        {
            Surveyor = surveyor;
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
