using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class Tripod : AggregateRoot
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime PurchasedAt { get; private set; }

        protected Tripod(AggregateId id)
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

        public void ChangeSerialNumber(string serialNumber)
            => SerialNumber = serialNumber;

        public void ChangePurchasedAt(DateTime purchasedAt)
            => PurchasedAt = purchasedAt;

        public static Tripod Create(Guid id, string brand, string model, string serialNumber, DateTime purchasedAt)
        {
            var tripod = new Tripod(id);
            tripod.ChangeBrand(brand);
            tripod.ChangeModel(model);
            tripod.ChangeSerialNumber(serialNumber);
            tripod.ChangePurchasedAt(purchasedAt);

            return tripod;
        }
    }
}
