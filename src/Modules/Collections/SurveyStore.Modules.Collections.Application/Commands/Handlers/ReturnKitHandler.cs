using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Time;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnKitHandler : ICommandHandler<ReturnKit>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitRepository _kitRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ISurveyorRepository _surveyRepository;
        private readonly IClock _clock;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public ReturnKitHandler(IKitCollectionRepository kitCollectionRepository,
            IKitRepository kitRepository,
            IStoreRepository storeRepository,
            ISurveyorRepository surveyRepository,
            IClock clock,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _surveyRepository = surveyRepository;
            _clock = clock;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task HandleAsync(ReturnKit command)
        {
            var kit = await _kitRepository.GetByIdAsync(command.KitId);
            if (kit is null)
            {
                throw new KitNotFoundException(command.KitId);
            }

            var surveyor = await _surveyRepository.GetByIdAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var store = await _storeRepository.GetByIdAsync(command.ReturnStoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.ReturnStoreId);
            }

            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsOpenKitCollection(command.KitId) & new IsSurveyorKitCollection(command.SurveyorId));

            if (kitCollection is null)
            {
                throw new CannotReturnKitCollectionException(command.KitId);
            }

            kitCollection.Return(store.Id, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kitCollection);

            await _domainEventDispatcher.DispatchAsync(kitCollection.Events.ToArray());
        }
    }
}
