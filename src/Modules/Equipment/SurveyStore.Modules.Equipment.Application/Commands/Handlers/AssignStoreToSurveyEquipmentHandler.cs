using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Core.Repositories;
using SurveyStore.Shared.Abstractions.Kernel;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AssignStoreToSurveyEquipmentHandler : ICommandHandler<AssignStoreToSurveyEquipment>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public AssignStoreToSurveyEquipmentHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _domainEventDispatcher = domainEventDispatcher;
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
        }
    }
}
