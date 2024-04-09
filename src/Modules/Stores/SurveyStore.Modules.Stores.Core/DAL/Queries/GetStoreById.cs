using System;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Stores.Core.DAL.Queries
{
    public record GetStoreById(Guid Id) : IQuery<StoreDto>;
}
