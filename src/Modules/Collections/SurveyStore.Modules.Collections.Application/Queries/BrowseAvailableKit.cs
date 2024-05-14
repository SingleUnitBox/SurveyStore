using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Collections.Application.Queries
{
    public record BrowseAvailableKit : IQuery<IReadOnlyCollection<KitDto>>;
}
