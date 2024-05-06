using SurveyStore.Modules.Equipment.Domain.Kit.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class Kit : AggregateRoot
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime PurchasedAt { get; private set; }

        protected Kit(AggregateId id)
        {
            Id = id;
        }

        public void ChangeBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new EmptyBrandException(GetType().Name);
            }
            Brand = brand;
        }

        public void ChangeModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new EmptyModelException(GetType().Name);
            }

            Model = model;
        }

        public void ChangeSerialNumber(string serialNumber)
            => SerialNumber = serialNumber;

        public void ChangePurchasedAt(DateTime purchasedAt)
            => PurchasedAt = purchasedAt;
    }
}

