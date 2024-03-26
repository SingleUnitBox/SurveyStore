using System;
using SurveyStore.Modules.Collections.Core.Types;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Collection : AggregateRoot
    {
        public Surveyor? Surveyor { get; private set; }
        public Store? Store { get; private set; }
        public SurveyEquipmentId SurveyEquipmentId { get; private set; }
        public DateTime? CollectedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        public Collection(AggregateId id, SurveyEquipmentId surveyEquipmentId)
        {
            Id = id;
            SurveyEquipmentId = surveyEquipmentId;
        }

        public static Collection Create(Guid id, Guid surveyEquipmentId)
            => new(id, surveyEquipmentId);
    }
}
