using SurveyStore.Modules.Calibrations.Domain.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Types;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Calibrations.Domain.Entities
{
    public class Calibration : AggregateRoot
    {
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public SurveyEquipment SurveyEquipment { get; private set; }
        public DateTime? CalibrationDueDate { get; private set; }
        public TimeSpan? CalibrationInterval { get; private set; }
        public string CertificateNumber { get; private set; }
        public CalibrationStatus CalibrationStatus { get; private set; }

        internal Calibration(AggregateId id, SurveyEquipmentId surveyEquipmentId)
            {
                Id = id;
                SurveyEquipmentId = surveyEquipmentId;
                CalibrationStatus = CalibrationStatus.Pending;
            }

        public void ChangeCalibrationDueDate(DateTime calibrationDate)
        {
            if (calibrationDate.Date <= CalibrationDueDate.Value.Date)
            {
                throw new InvalidCalibrationDateException(calibrationDate);
            }

            CalibrationDueDate = calibrationDate;
            IncrementVersion();
        }
 
        public void ChangeCalibrationInterval(TimeSpan calibrationInterval)
        {
            CalibrationInterval = calibrationInterval;
            IncrementVersion();
        }

        public void ChangeCertificateNumber(string certificateNumber)
        {
            CertificateNumber = certificateNumber;
            IncrementVersion();
        }
        public void ChangeCalibrationStatus(CalibrationStatus calibrationStatus)
        {
            CalibrationStatus = calibrationStatus;
            IncrementVersion();
        }

        public static Calibration Create(Guid id, Guid surveyEquipmentId)
        {
            var calibration = new Calibration(id, surveyEquipmentId);
            calibration.ClearEvents();

            return calibration;
        }
    }
}
