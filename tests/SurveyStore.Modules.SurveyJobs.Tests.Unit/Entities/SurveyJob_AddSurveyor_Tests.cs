using Shouldly;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Tests;
using System;
using System.Linq;
using Xunit;

namespace SurveyStore.Modules.SurveyJobs.Tests.Unit.Entities
{
    public class SurveyJob_AddSurveyor_Tests
    {
        private void Act(Surveyor surveyor) => _surveyJob.AddSurveyor(surveyor);

        [Fact]
        public void add_surveyor_should_add_to_survey_job()
        {
            var surveyor = Surveyor.Create(Guid.NewGuid(), "johnDoe@gmail.com", "John", "Doe");

            Act(surveyor);

            _surveyJob.Surveyors.ShouldNotBeNull();
            _surveyJob.Surveyors.Count().ShouldBe(1);
        }

        private readonly SurveyJob _surveyJob;
        private readonly TestClock _clock;

        public SurveyJob_AddSurveyor_Tests()
        {
            _clock = new TestClock();
            _surveyJob = SurveyJob.Create(Guid.NewGuid(), "testSurveyJob", _clock.Clock.Current(),
                _clock.Clock.Current().AddDays(10), "topo", 500, null);
        }
    }
}
