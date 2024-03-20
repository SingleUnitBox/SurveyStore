using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Core.Repositories;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
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

            equipment.AssignStore(store);
            await _surveyEquipmentRepository.UpdateAsync(equipment);
        }
    }
}
