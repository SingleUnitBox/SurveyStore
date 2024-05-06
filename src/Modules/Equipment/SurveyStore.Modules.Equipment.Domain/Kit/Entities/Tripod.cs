using SurveyStore.Modules.Equipment.Domain.Kit.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class Tripod : Kit
    {
        public Tripod(AggregateId id) : base(id)
        {
            
        }

        public static Tripod Create(Guid id, string brand, string model,
            string serialNumber, DateTime purchasedAt)
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
