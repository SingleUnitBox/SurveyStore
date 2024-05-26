﻿using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.SurveyJobs.Application.DTO
{
    public class SurveyJobDto
    {
        public string Name { get; set; }
        public DateTime BriefIssued { get; set; }
        public DateTime DueDate { get; set; }
        public string SurveyType { get; set; }
        public IEnumerable<SurveyorDto> Surveyors { get; set; }
        public IEnumerable<DocumentDto> Documents { get; set; }
    }
}
