using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CreateCollectionHandler : ICommandHandler<CreateCollection>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;

        public CreateCollectionHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
        }

        public async Task HandleAsync(CreateCollection command)
        {
            var equipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (equipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var store = await _storeRepository.GetByIdAsync(command.CollectionStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.CollectionStoreId);
            }

            //equipment.AssignStore(store);
            await _surveyEquipmentRepository.UpdateAsync(equipment);
            //await _domainEventDispatcher.DispatchAsync(equipment.Events.ToArray());
        }
    }
}
