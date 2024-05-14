using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.Collections.Application.DTO
{
    public class CollectionDto
	{
		public AggregateId Id { get; set; }
        public SurveyorDto? Surveyor { get; private set; }
        public StoreId? CollectionStoreId { get; private set; }
        public StoreId? ReturnStoreId { get; private set; }
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }
	}
}

