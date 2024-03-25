using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Services;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AssignStoreToSurveyEquipmentHandler : ICommandHandler<AssignStoreToSurveyEquipment>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public AssignStoreToSurveyEquipmentHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IDomainEventDispatcher domainEventDispatcher,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _domainEventDispatcher = domainEventDispatcher;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AssignStoreToSurveyEquipment command)
        {
            var equipment = await _surveyEquipmentRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (equipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SerialNumber);
            }

            var store = await _storeRepository.GetByNameAsync(command.StoreName);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreName);
            }

            equipment.AssignStore(store);
            await _surveyEquipmentRepository.UpdateAsync(equipment);
            await _domainEventDispatcher.DispatchAsync(equipment.Events.ToArray());

            var events = _eventMapper.MapAll(equipment.Events);
            await _messageBroker.PublishAsync(events.ToArray());
        }
    }
}
