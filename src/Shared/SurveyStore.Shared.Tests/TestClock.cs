using System.Runtime.CompilerServices;
using SurveyStore.Shared.Infrastructure.Time;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Users.Tests.Integration")]
[assembly: InternalsVisibleTo("SurveyStore.Modules.SurveyJobs.Tests.Unit")]
namespace SurveyStore.Shared.Tests
{
    public class TestClock
    {
        internal ClockUtc Clock;
        public TestClock()
        {
            Clock = new ClockUtc();
        }
    }
}
