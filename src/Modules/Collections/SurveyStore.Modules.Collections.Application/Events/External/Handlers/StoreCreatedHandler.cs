using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class StoreCreatedHandler : IEventHandler<StoreCreated>
    {
        private readonly IStoreRepository _storeRepository;

        public StoreCreatedHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task HandleAsync(StoreCreated @event)
        {
            var store = await _storeRepository.GetByIdAsync(@event.Id);
            if (store is not null)
            {
                return;
            }

            store = Store.Create(@event.Id, @event.Name);
            await _storeRepository.AddAsync(store);
        }
    }
}
