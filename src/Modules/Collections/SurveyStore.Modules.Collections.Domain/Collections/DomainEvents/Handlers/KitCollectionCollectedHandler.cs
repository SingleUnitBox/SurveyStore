using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.DomainEvents.Handlers
{
    public class KitCollectionCollectedHandler : IDomainEventHandler<KitCollectionCollected>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;

        public KitCollectionCollectedHandler(IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
        }

        public async Task HandleAsync(KitCollectionCollected @event)
        {
            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollectionById(@event.KitId));
            if (kitCollection is null)
            {
                throw new FreeKitCollectionNotFoundException(@event.KitId);
            }

            var surveyor = await _surveyorRepository.GetByIdAsync(@event.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(@event.SurveyorId);
            }

            kitCollection.Collect(surveyor, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kitCollection);
        }
    }
}
