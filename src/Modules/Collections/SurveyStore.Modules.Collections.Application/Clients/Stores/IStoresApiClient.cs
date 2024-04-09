using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Clients.Stores.DTO;

namespace SurveyStore.Modules.Collections.Application.Clients.Stores
{
    public interface IStoresApiClient
    {
        Task<StoreDto> GetStoreAsync(Guid id);
    }
}
