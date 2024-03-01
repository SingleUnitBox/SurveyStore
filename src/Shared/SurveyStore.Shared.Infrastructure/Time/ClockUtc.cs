using SurveyStore.Shared.Abstractions.Time;
using System;

namespace SurveyStore.Shared.Infrastructure.Time
{
    internal class ClockUtc : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
    }
}
