using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace SurveyStore.Modules.Stores.Core.DAL.Queries
{
    public record BrowseStores() : IQuery<IReadOnlyCollection<StoreDto>>;
}
