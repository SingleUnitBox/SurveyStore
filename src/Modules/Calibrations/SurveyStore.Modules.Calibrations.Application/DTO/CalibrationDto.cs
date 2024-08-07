﻿using SurveyStore.Modules.Calibrations.Domain.ValueObjects;
using System;

namespace SurveyStore.Modules.Calibrations.Application.DTO
{
    public class CalibrationDto
    {
        public Guid Id { get; set; }
        public Guid SurveyEquipmentId { get; set; }
        //public string SerialNumber { get; set; }
        public DateTime? CalibrationDueDate { get; set; }
        public string CertificateNumber { get; set; }
        public CalibrationStatus CalibrationStatus { get; set; }
    }
}
