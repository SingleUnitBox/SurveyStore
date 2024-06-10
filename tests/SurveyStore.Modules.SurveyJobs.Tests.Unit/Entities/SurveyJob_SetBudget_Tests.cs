using Shouldly;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Tests;
using System;
using Xunit;

namespace SurveyStore.Modules.SurveyJobs.Tests.Unit.Entities
{
    public class SurveyJob_SetBudget_Tests
    {
        private void Act(int budget) => _surveyJob.SetBudget(budget);

        [Fact]
        public void correct_input_should_change_survey_job_budget()
        {
            var budget = 500;

            Act(budget);

            _surveyJob.Budget.ShouldBeOfType<Money>();
            _surveyJob.Budget.Value.ShouldBe(budget);
        }

        private readonly SurveyJob _surveyJob;
        private readonly TestClock _clock;

        public SurveyJob_SetBudget_Tests()
        {
            _clock = new TestClock();
            _surveyJob = _surveyJob = SurveyJob.Create(Guid.NewGuid(), "testSurveyJob", _clock.Clock.Current(),
                _clock.Clock.Current().AddDays(10), "topo", null, null);
        }
    }
}
