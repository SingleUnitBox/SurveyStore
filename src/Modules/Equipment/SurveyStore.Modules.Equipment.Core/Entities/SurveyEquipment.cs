using System;
using SurveyStore.Modules.Equipment.Core.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class SurveyEquipment : AggregateRoot
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime PurchasedAt { get; private set; }
        public DateTime? CalibrationDate { get; private set; }
        public TimeSpan? CalibrationInterval { get; private set; }
        public Store Store { get; set; }
        //public Surveyor? Surveyor { get; set; }

        protected SurveyEquipment(AggregateId id)
        {
            Id = id;
        }

        public void ChangeBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new EmptyBrandException();
            }

            Brand = brand;
        }

        public void ChangeModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new EmptyModelException();
            }

            Model = model;
        }

        public void ChangeDescription(string description)
            => Description = description;

        public void ChangeSerialNumber(string serialNumber)
            => SerialNumber = serialNumber;

        public void ChangePurchasedAt(DateTime purchasedAt)
            => PurchasedAt = purchasedAt;

        public void ChangeCalibrationDate(DateTime calibrationDate)
            => CalibrationDate = calibrationDate;

        public void ChangeCalibrationInterval(TimeSpan calibrationInterval)
            => CalibrationInterval = calibrationInterval;

        public void ChangeStore(Store store)
            => Store = store;
    }
}
 