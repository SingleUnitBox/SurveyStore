using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents
{
    //public record StoreAssigned(SurveyEquipment SurveyEquipment, StoreId StoreId) : IDomainEvent;
    //public record StoreAssigned(Kit Kit, StoreId storeId) : IDomainEvent;
    public class StoreAssigned : IDomainEvent
    {
        public SurveyEquipment SurveyEquipment { get; init; }
        public Kit Kit { get; init; }
        public StoreId StoreId { get; init; }

        public StoreAssigned(SurveyEquipment surveyEquipment, StoreId storeId)
        {
            SurveyEquipment = surveyEquipment;
            StoreId = storeId;
        }

        public StoreAssigned(Kit kit, StoreId storeId)
        {
            Kit = kit;
            StoreId = storeId;
        }
    }
}
