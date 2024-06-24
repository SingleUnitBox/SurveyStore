using System.Linq;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnSurveyEquipmentHandler : ICommandHandler<ReturnSurveyEquipment>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IClock _clock;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public ReturnSurveyEquipmentHandler(ICollectionRepository collectionRepository,
            ISurveyorRepository surveyorRepository,
            IStoreRepository storeRepository,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            IClock clock,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _collectionRepository = collectionRepository;
            _surveyorRepository = surveyorRepository;
            _storeRepository = storeRepository;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _clock = clock;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(ReturnSurveyEquipment command)
        {
            var collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is null)
            {
                throw new OpenCollectionNotFoundException(command.SurveyEquipmentId);
            }

            if (command.SurveyorId != collection.Surveyor.Id)
            {
                throw new CollectionDoesNotBelongToSurveyorException(collection.Id, command.SurveyorId);
            }

            var surveyor = await _surveyorRepository.GetAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var returnStore = await _storeRepository.GetByIdAsync(command.ReturnStoreId);
            if (returnStore is null)
            {
                throw new StoreNotFoundException(command.ReturnStoreId);
            }

            collection.Return(returnStore.Id, _clock.Current());
            await _collectionRepository.UpdateAsync(collection);

            var events = _eventMapper.MapAll(collection.Events);
            await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
