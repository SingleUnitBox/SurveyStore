using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Equipment.Application.Kit.Queries
{
    public record BrowseKit() : IQuery<IReadOnlyCollection<KitDto>>;
}
