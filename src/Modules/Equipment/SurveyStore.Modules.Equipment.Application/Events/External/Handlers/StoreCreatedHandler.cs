using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;

namespace SurveyStore.Modules.Equipment.Application.Events.External.Handlers
{
    internal class StoreCreatedHandler : IEventHandler<StoreCreated>
    {
        private readonly IStoreRepository _repository;
        private readonly ILogger<StoreCreatedHandler> _logger;

        public StoreCreatedHandler(IStoreRepository repository,
            ILogger<StoreCreatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task HandleAsync(StoreCreated @event)
        {
            var store = await _repository.GetByIdAsync(@event.Id);
            if (store is not null)
            {
                return;
            }

            store = new Store
            {
                Id = @event.Id,
                Name = @event.Name,
            };

            await _repository.AddAsync(store);
            _logger.LogInformation($"Store with id '{store.Id}' has been created.");
        }
    }
}
