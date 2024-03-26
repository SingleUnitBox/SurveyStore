using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Collection : AggregateRoot
    {
        public Surveyor? Surveyor { get; set; }
        public Store? Store { get; set; }
        public SurveyEquipment SurveyEquipment { get; set; }
        public DateTime? CollectedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public static Collection Create(Guid id, Guid surveyEquipmentId)
            => new Collection
            {
                Id = id,
                SurveyEquipment = 
            };
    }
}
