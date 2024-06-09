using System;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class Date
    {
        public DateTime Value { get; set; }

        private Date(DateTime value)
        {
            Value = value;
        }

        public static Date Create(DateTime value)
        {
            var date = new Date(value);

            return date;
        }

        public static implicit operator Date(DateTime value) => new Date(value);
        public static implicit operator DateTime(Date date) => date.Value;
    }
}
