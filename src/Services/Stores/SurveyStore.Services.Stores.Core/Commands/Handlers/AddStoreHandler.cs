using SurveyStore.Services.Stores.Core.Entities;
using SurveyStore.Services.Stores.Core.Events;
using SurveyStore.Services.Stores.Core.Exceptions;
using SurveyStore.Services.Stores.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Core.Commands.Handlers
{
    public class AddStoreHandler : ICommandHandler<AddStore>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMessageBroker _messageBroker;

        public AddStoreHandler(IStoreRepository storeRepository,
            IMessageBroker messageBroker)
        {
            _storeRepository = storeRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddStore command)
        {
            var store = await _storeRepository.GetByNameAsync(command.Name);
            if (store is not null)
            {
                throw new StoreAlreadyExistsException(command.Name);
            }

            if (command.OpeningTime >= command.ClosingTime)
            {
                throw new InvalidOperationTimeException(command.OpeningTime, command.ClosingTime);
            }

            store = new Store
            {
                Id = command.Id,
                Name = command.Name,
                Location = command.Location,
                OpeningTime = command.OpeningTime,
                ClosingTime = command.ClosingTime,
            };

            await _storeRepository.AddAsync(store);
            await _messageBroker.PublishAsync(new StoreCreated(command.Id, command.Name));
        }
    }
}
