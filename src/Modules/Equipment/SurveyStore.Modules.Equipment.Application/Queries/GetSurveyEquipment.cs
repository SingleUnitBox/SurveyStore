using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.Equipment.Application.Queries
{
    public record GetSurveyEquipment(Guid Id) : IQuery<SurveyEquipmentDto>;
}
