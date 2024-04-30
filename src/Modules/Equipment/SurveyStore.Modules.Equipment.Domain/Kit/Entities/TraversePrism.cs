using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class TraversePrism : AggregateRoot
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public DateTime PurchasedAt { get; private set; }

        public TraversePrism(AggregateId id)
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

        public static TraversePrism Create(Guid id, string brand, string model, string serialNumber, DateTime purchasedAt)
        {
            var prism = new TraversePrism(id);
            prism.ChangeBrand(brand);
            prism.ChangeModel(model);
            prism.ChangeSerialNumber(serialNumber);
            prism.ChangePurchasedAt(purchasedAt);

            return prism;
        }
    }
}
