﻿using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AddSurveyJob(DateTime BriefIssued,
        DateTime DueDate, string SurveyType, IEnumerable<string> DocumentLinks = null) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
