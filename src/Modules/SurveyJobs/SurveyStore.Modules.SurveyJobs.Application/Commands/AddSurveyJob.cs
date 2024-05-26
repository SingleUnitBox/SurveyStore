﻿using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands
{
    public record AddSurveyJob(DateTime BriefIssued,
        DateTime DueDate, string SurveyType) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
