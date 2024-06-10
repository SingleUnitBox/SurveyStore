using Shouldly;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Tests;
using System;
using System.Linq;
using Xunit;

namespace SurveyStore.Modules.SurveyJobs.Tests.Unit.Entities
{
    public class SurveyJob_AddDocument_Tests
    {
        private void Act(Document document) => _surveyJob.AddDocument(document);

        [Fact]
        public void add_document_should_add_to_survey_job()
        {
            var document = Document.Create(Guid.NewGuid(), "photo", "http://link.com");

            Act(document);

            _surveyJob.Documents.ShouldNotBeNull();
            _surveyJob.Documents.Count().ShouldBe(1);
        }

        private readonly TestClock _clock;
        private readonly SurveyJob _surveyJob;
        public SurveyJob_AddDocument_Tests()
        {
            _clock = new TestClock();
            _surveyJob = SurveyJob.Create(Guid.NewGuid(), "testSurveyJob", _clock.Clock.Current(),
                _clock.Clock.Current().AddDays(10), "topo", 500, null);
        }
    }
}