using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        public Surveyor Surveyor { get; private set; }
        public DateTime BriefIssued { get; private set; }
        public DateTime DueDate { get; private set; }
        public string SurveyType { get; private set; }
        public IEnumerable<Document> Documents => _documents;
        private readonly IEnumerable<Document> _documents = new List<Document>();

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

        public static SurveyJob Create(Guid id, Surveyor surveyor, DateTime briefIssued, DateTime dueDate)
        {
            var surveyJob = new SurveyJob(id);
            surveyJob.ChangeSurveyor(surveyor);
            surveyJob.ChangeBriefIssued(briefIssued);
            surveyJob.ChangeDueDate(dueDate);

            return surveyJob;
        }
    }
}
