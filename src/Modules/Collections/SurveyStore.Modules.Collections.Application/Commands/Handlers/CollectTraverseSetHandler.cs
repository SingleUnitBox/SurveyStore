using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Time;
using System.Linq;
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
        private readonly ICollectionService _collectionService;
        private readonly IKitCollectionService _kitCollectionService;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public CollectTraverseSetHandler(ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            ICollectionService collectionService,
            IKitCollectionService kitCollectionService,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _collectionService = collectionService;
            _kitCollectionService = kitCollectionService;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task HandleAsync(CollectTraverseSet command)
        {
            var surveyor = await _surveyorRepository.GetByIdAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var toBeCollected = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsFreeCollection(command.SurveyEquipmentId));
            if (toBeCollected is null)
            {
                throw new FreeCollectionNotFoundException(command.SurveyEquipmentId);
            }

            var openCollections = await _collectionRepository
                .BrowseAsPredicateExpressionAsync(new IsOpenCollection() & new IsSurveyorCollection(surveyor.Id));

            var now = _clock.Current();
            _collectionService.Collect(openCollections, toBeCollected, surveyor, now);

            var openKitCollections = await _kitCollectionRepository
                .BrowseAsPredicateExpression(new IsOpenKitCollection() & new IsSurveyorKitCollection(surveyor.Id));
            var kitToBeCollected = await _kitCollectionService.GatherTraverseSet(openKitCollections, surveyor, now);
            foreach (var kit in kitToBeCollected)
            {
                kit.Collect(surveyor, now);
            }

            await _collectionRepository.UpdateAsync(toBeCollected);

            var domainEvents = kitToBeCollected.SelectMany(k => k.Events);
            await _domainEventDispatcher.DispatchAsync(domainEvents.ToArray());
        }
    }
}
