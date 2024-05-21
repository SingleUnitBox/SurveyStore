using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnTraverseSetHandler : ICommandHandler<ReturnTraverseSet>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;       
        private readonly IStoreRepository _storeRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ICollectionRepository _collectionRepository;       
        private readonly ICollectionPolicy _collectionPolicy;
        private readonly IKitRepository _kitRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitCollectionService _kitCollectionService;

        public ReturnTraverseSetHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IKitRepository kitRepository,
            IStoreRepository storeRepository,
            ISurveyorRepository surveyorRepository,
            ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository,
            ICollectionPolicy collectionPolicy,
            IKitCollectionService kitCollectionService)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _surveyorRepository = surveyorRepository;
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _collectionPolicy = collectionPolicy;
            _kitCollectionService = kitCollectionService;
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

            if (!_collectionPolicy.CanBeReturned(collection, surveyor))
            {
                throw new ReturningOtherCollectionException(collection.Id, surveyor.Id);
            }

            var openKitCollections = await _kitCollectionRepository
                .BrowseOpenKitCollectionsBySurveyorAsync(surveyor.Id);

            var (tripodsBool, tripods) = _kitCollectionService.IsTraverseSetFullForReturn(openKitCollections);
            if (!_kitCollectionService.IsTraverseSetFullForReturn(openKitCollections))
            {
                throw new IncompleteTraverseSetException();
            }
        }
    }
}
