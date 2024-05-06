using SurveyStore.Modules.Equipment.Domain.Kit.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Equipment.Domain.Kit.Entities
{
    public class DetailPole : Kit
    {
        public DetailPole(AggregateId id) : base(id)
        {
            
        }

        public static DetailPole Create(Guid id, string brand, string model, string serialNumber, DateTime purchasedAt)
        {
            var pole = new DetailPole(id);
            pole.ChangeBrand(brand);
            pole.ChangeModel(model);
            pole.ChangeSerialNumber(serialNumber);
            pole.ChangePurchasedAt(purchasedAt);

            return pole;
        }
    }
}
