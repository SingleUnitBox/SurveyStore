using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Mappings;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Services
{
    internal class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMessageBroker _messageBroker;

        public StoreService(IStoreRepository storeRepository,
            IMessageBroker messageBroker)
        {
            _storeRepository = storeRepository;
            _messageBroker = messageBroker;
        }

        public async Task<IReadOnlyList<StoreDto>> BrowseAsync()
            => (await _storeRepository.BrowseAsync())
                .Select(x => x.AsDto())
                .ToList();

        public async Task<StoreDto> GetAsync(Guid id)
        {
            var store = await _storeRepository.GetAsync(id);
            if (store is null)
            {
                throw new StoreNotFoundException(id);
            }

            return store.AsDto();
        }

        public async Task UpdateAsync(StoreDto storeDto)
        {
            var store = await _storeRepository.GetAsync(storeDto.Id);
            if (store is null)
            {
                throw new StoreNotFoundException(storeDto.Id);
            }

            if (storeDto.OpeningTime >= storeDto.ClosingTime)
            {
                throw new InvalidOperationTimeException(storeDto.OpeningTime, storeDto.ClosingTime);
            }

            store.OpeningTime = storeDto.OpeningTime;
            store.ClosingTime = storeDto.ClosingTime;

            await _storeRepository.UpdateAsync(store);
        }
    }
}
