using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class SurveyJob : AggregateRoot
    {
        public Surveyor Surveyor { get; private set; }
        public DateTime BriefIssued { get; private set; }
        public DateTime DueDate { get; private set; }
        public SurveyJobTypes SurveyType { get; private set; }
        public IEnumerable<Document> Documents { get; private set; }
    }
}
