﻿using System;

namespace SurveyStore.Modules.Collections.Application.Clients.Calibrations.DTO
{
    public class CalibrationDto
    {
        public Guid Id { get; set; }
        public Guid SurveyEquipmentId { get; set; }
        public DateTime? CalibrationDueDate { get; set; }
        //public TimeSpan CalibrationInterval { get; set; }
        public string CertificateNumber { get; set; }
        public string CalibrationStatus { get; set; }
    }
}
