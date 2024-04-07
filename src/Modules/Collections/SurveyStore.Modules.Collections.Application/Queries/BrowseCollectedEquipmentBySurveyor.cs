using System;
using System.Collections.Generic;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Collections.Application.Queries
{
    public record BrowseCollectedEquipmentBySurveyor(Guid SurveyorId) : IQuery<IEnumerable<SurveyEquipmentDto>>;
}
