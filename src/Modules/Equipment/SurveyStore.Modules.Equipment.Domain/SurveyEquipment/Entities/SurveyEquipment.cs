using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class SurveyEquipment : AggregateRoot
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime PurchasedAt { get; private set; }

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
    }
}
