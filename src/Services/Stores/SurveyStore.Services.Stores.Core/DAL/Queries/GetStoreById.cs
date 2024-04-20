using System;
using SurveyStore.Services.Stores.Core.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Services.Stores.Core.DAL.Queries
{
    public record GetStoreById(Guid Id) : IQuery<StoreDto>;
}
