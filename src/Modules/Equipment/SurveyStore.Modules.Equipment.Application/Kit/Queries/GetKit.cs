using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System;

namespace SurveyStore.Modules.Equipment.Application.Kit.Queries
{
    public record GetKit(Guid id) : IQuery<KitDto>;
}
