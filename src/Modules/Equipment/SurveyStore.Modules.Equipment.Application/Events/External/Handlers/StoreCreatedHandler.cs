using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Modules.Stores.Messages.Events;

namespace SurveyStore.Modules.Equipment.Application.Events.External.Handlers
{
    internal class StoreCreatedHandler : IEventHandler<StoreCreated>
    {
        private readonly IStoreRepository _repository;

        public StoreCreatedHandler(IStoreRepository repository)
        {
            _repository = repository;
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
        }
    }
}
