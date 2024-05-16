using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class TraversePrism : Kit
    {
        public TraversePrism(AggregateId id) : base(id)
        {
        }

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
