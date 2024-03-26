using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreHandler : ICommandHandler<AssignStore>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;

        public AssignStoreHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
        }

        public async Task HandleAsync(AssignStore command)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.Id);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.Id);
            }

            var store = await _storeRepository.GetByIdAsync(command.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreId);
            }

            surveyEquipment.AssignStore(command.StoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
        }
    }
}
