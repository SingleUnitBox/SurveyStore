﻿using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SurveyStore.Modules.Collections.Application.Clients.Stores;
using SurveyStore.Modules.Collections.Application.Clients.Stores.DTO;
using SurveyStore.Modules.Collections.Application.Exceptions;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    internal sealed class StoreCreatedHandler : IEventHandler<StoreCreated>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IStoresApiClient _storesApiClient;
        private readonly ILogger<StoreCreatedHandler> _logger;

        public StoreCreatedHandler(IStoreRepository storeRepository,
            ILogger<StoreCreatedHandler> logger)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }
        public async Task HandleAsync(StoreCreated @event)
        {
            var store = await _storeRepository.GetByIdAsync(@event.Id);
            if (store is not null)
            {
                return;
            }

            var storeDto = await _storesApiClient.GetStoreAsync(@event.Id);
            if (store is null)
            {
                throw new StoreNotFoundException(@event.Id);
            }

            store = Store.Create(@event.Id, storeDto.Name);
            await _storeRepository.AddAsync(store);
            _logger.LogInformation($"Created a store with id '{@event.Id}'.");
        }
    }
}
