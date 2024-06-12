﻿using System;

namespace SurveyStore.Modules.Payments.Domain.ValueObjects
{
    public class Date
    {
        public DateTime Value { get; private set; }
        public Date(DateTime value)
        {
            Value = value;
        }

        public static implicit operator Date(DateTime value) => new(value);
        public static implicit operator DateTime(Date date) => date.Value;
    }
}
