using Shouldly;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Tests;
using System;
using Xunit;

namespace SurveyStore.Modules.SurveyJobs.Tests.Unit.Entities
{
    public class SurveyJob_ChangeSurveyJobName_Tests
    {
        private void Act(string name) => _surveyJob.ChangeSurveyJobName(name);

        [Fact]
        public void correct_input_should_change_survey_job_name()
        {
            var newName = "newSurveyJobName";
            Act(newName);

            _surveyJob.Name.Name.ShouldBe(newName);
        }

        public SurveyJob_ChangeSurveyJobName_Tests()
        {
            _clock = new TestClock();
            _surveyJob = SurveyJob.Create(Guid.NewGuid(), "testSurveyJob", _clock.Clock.Current(),
                _clock.Clock.Current().AddDays(10), "topo", 500, null);
        }

        private readonly SurveyJob _surveyJob;
        private readonly TestClock _clock;
    }
}