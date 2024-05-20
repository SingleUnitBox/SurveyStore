using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnTraverseSetHandler : ICommandHandler<ReturnTraverseSet>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IKitRepository _kitRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;

        public ReturnTraverseSetHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IKitRepository kitRepository,
            IStoreRepository storeRepository,
            ISurveyorRepository surveyorRepository,
            ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _surveyorRepository = surveyorRepository;
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
        }

        public async Task HandleAsync(ReturnTraverseSet command)
        {
            var surveyor = await _surveyorRepository.GetAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var store = await _storeRepository.GetByIdAsync(command.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.ReturnStoreId);
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is null)
            {
                throw new OpenCollectionNotFoundException(command.SurveyEquipmentId);
            }

            if (collection.Surveyor.Id != surveyor.Id)
            {
                throw new ReturningOtherCollectionException(collection.Id, surveyor.Id);
            }

            collection.
        }
    }
}
