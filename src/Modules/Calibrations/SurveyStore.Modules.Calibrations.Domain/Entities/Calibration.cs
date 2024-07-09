using SurveyStore.Modules.Calibrations.Domain.Exceptions;
using SurveyStore.Modules.Calibrations.Domain.Specifications.Calibrations;
using SurveyStore.Modules.Calibrations.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Specification;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Calibrations.Infrastructure")]
namespace SurveyStore.Modules.Calibrations.Domain.Entities
{
    public class Calibration : AggregateRoot
    {
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public SurveyEquipment SurveyEquipment { get; private set; }
        public Date CalibrationDueDate { get; private set; }
        public CertificateNumber CertificateNumber { get; private set; }
        public CalibrationStatus CalibrationStatus { get; private set; }

        internal Calibration(AggregateId id, SurveyEquipmentId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
            CalibrationStatus = CalibrationStatuses.Unknown;
        }

        public void ChangeCalibrationDueDate(Date calibrationDueDate, DateTime now)
        {
            if (calibrationDueDate <= CalibrationDueDate)
            {
                throw new InvalidCalibrationDateException(calibrationDueDate);
            }

            var isDue = new IsDue(calibrationDueDate, now).Check(calibrationDueDate);
            if (isDue)
            {
                ChangeCalibrationStatus(CalibrationStatuses.CalibrationDue);
                goto SetCalibrationDate;
            }

            var IsUncalibrated = new IsUncalibrated(calibrationDueDate, now).Check(calibrationDueDate);
            if (IsUncalibrated)
            {
                ChangeCalibrationStatus(CalibrationStatuses.Uncalibrated);
                goto SetCalibrationDate;
            }

            var isCalibrated = new IsCalibrated(calibrationDueDate, now).Check(calibrationDueDate);
            if (isCalibrated)
            {
                ChangeCalibrationStatus(CalibrationStatuses.Calibrated);
                goto SetCalibrationDate;
            }

            SetCalibrationDate: 
            CalibrationDueDate = calibrationDueDate;
            IncrementVersion();
        }

        public void ChangeCertificateNumber(string certificateNumber)
        {
            CertificateNumber = certificateNumber;
            IncrementVersion();
        }
        private void ChangeCalibrationStatus(CalibrationStatus calibrationStatus)
        {
            CalibrationStatus = calibrationStatus;
            IncrementVersion();
        }

        public void Renew(DateTime now)
        {
            var calibrationRenewDate = now.AddYears(1);
            ChangeCalibrationDueDate(calibrationRenewDate, now);
        }

        public static Calibration Create(Guid id, Guid surveyEquipmentId)
        {
            var calibration = new Calibration(id, surveyEquipmentId);
            calibration.ClearEvents();

            return calibration;
        }
    }
}
