using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Equipment.Application.Queries
{
    public record BrowseSurveyEquipment() : IQuery<IEnumerable<SurveyEquipmentDto>>;
}
