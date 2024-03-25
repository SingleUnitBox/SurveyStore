using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Core.Repositories;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreToSurveyEquipmentHandler : ICommandHandler<AssignStoreToSurveyEquipment>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;

        public AssignStoreToSurveyEquipmentHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
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

            //equipment.AssignStore(store);
            await _surveyEquipmentRepository.UpdateAsync(equipment);
            //await _domainEventDispatcher.DispatchAsync(equipment.Events.ToArray());
        }
    }
}
