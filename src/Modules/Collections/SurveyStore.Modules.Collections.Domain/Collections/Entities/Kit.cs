using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Kit : AggregateRoot
    {
        public Store Store { get; private set; }
        public StoreId StoreId { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public string Type { get; private set; }

        protected Kit(AggregateId id, string brand, string model, string serialNumber, string type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            SerialNumber = serialNumber;
            Type = type;
        }

        public void AssignStore(StoreId storeId)
        {
            if (StoreId == storeId)
            {
                return;
            }
            StoreId = storeId;
            AddEvent(new StoreAssignedToKit(this, storeId));
        }

        public void UnassignStore()
        {
            StoreId = null;
            IncrementVersion();
        }

        public static Kit Create(Guid id, string brand, string model, string serialNumber, string type)
        {
            var kit = new Kit(id, brand, model, serialNumber, type);
            kit.ClearEvents();
            kit.Version = 0;

            return kit;
        }
    }
}
