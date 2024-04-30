using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AddCollectionHandler : ICommandHandler<AddCollection>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ICollectionRepository _collectionRepository;

        public AddCollectionHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            ICollectionRepository collectionRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(AddCollection command)
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

            equipment.AssignStore(store.Id);
            await _surveyEquipmentRepository.UpdateAsync(equipment);
        }
    }
}
