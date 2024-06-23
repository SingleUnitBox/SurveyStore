using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectTraverseSetHandler : ICommandHandler<CollectTraverseSet>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IKitRepository _kitRepository;
        private readonly ICollectionService _collectionService;

        public CollectTraverseSetHandler(ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            IKitRepository kitRepository,
            ICollectionService collectionService)
        {
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _collectionService = collectionService;
        }

        public async Task HandleAsync(CollectTraverseSet command)
        {
            var surveyor = await _surveyorRepository.GetAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is null)
            {
                throw new FreeCollectionNotFoundException(command.SurveyEquipmentId);
            }

            //collection.Collect(surveyor, _clock.Current());
            var openCollections = await _collectionRepository.BrowseOpenCollectionsBySurveyorIdAsync(command.SurveyorId);
            var now = _clock.Current();

            //_collectionService.CanBeCollected(openCollections, surveyor, collection, now);

            var freeKitCollections = await _kitCollectionRepository.BrowseFreeKitCollectionsAsync();
            var kitSet = _collectionService.CollectTraverseSet(freeKitCollections, surveyor, collection, now);

            await _collectionRepository.UpdateAsync(collection);
            await _kitCollectionRepository.UpdateRangeAsync(freeKitCollections);

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            surveyEquipment.UnassignStore();
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            foreach (var kit in kitSet)
            {
                kit.UnassignStore();
            }
            await _kitRepository.UpdateRangeAsync(kitSet);
        }
    }
}
