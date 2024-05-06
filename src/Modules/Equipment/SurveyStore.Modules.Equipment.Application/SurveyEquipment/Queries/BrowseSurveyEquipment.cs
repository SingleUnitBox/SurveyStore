using SurveyStore.Modules.Equipment.Application.SurveyEquipment.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Queries
{
    public record BrowseSurveyEquipment() : IQuery<IEnumerable<SurveyEquipmentDto>>;
}
