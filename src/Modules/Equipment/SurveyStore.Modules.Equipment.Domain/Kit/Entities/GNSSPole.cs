using SurveyStore.Modules.Equipment.Domain.Kit.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class GNSSPole : Kit
    {
        public GNSSPole(AggregateId id) : base(id)
        {

        }

        public static GNSSPole Create(Guid id, string brand, string model, string serialNumber, DateTime purchasedAt)
        {
            var pole = new GNSSPole(id);
            pole.ChangeBrand(brand);
            pole.ChangeModel(model);
            pole.ChangeSerialNumber(serialNumber);
            pole.ChangePurchasedAt(purchasedAt);

            return pole;
        }
    }
}
