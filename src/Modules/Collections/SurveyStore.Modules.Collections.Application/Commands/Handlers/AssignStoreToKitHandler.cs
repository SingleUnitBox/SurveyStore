using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreToKitHandler : ICommandHandler<AssignStoreToKit>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitRepository _kitRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public AssignStoreToKitHandler(IKitCollectionRepository kitCollectionRepository,
            IKitRepository kitRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AssignStoreToKit command)
        {
            var kitCollection = await _kitCollectionRepository.GetOpenByKitAsync(command.KitId);
            if (kitCollection is not null)
            {
                throw new CannotAssignStoreException(command.KitId);
            }

            var kit = await _kitRepository.GetAsync(command.KitId);
            if (kit is null)
            {
                throw new KitNotFoundException(command.KitId);
            }

            var store = await _storeRepository.GetByIdAsync(command.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreId);
            }

            kit.AssignStore(command.StoreId);
            await _kitRepository.UpdateAsync(kit);

            kitCollection = await _kitCollectionRepository.GetFreeByKitAsync(command.KitId);
            if (kitCollection is not null)
            {
                kitCollection.ChangeCollectionStoreId(command.StoreId);
                await _kitCollectionRepository.UpdateAsync(kitCollection);
            }
            else
            {
                var events = _eventMapper.MapAll(kit.Events);
                await _messageBroker.PublishAsync(events.ToArray());
            }           
        }
    }
}
