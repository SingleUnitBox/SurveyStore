using SurveyStore.Modules.Equipment.Application.SurveyEquipment.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.Equipment.Application.SurveyEquipment.Queries
{
    public record GetSurveyEquipment(Guid Id) : IQuery<SurveyEquipmentDto>;
}
