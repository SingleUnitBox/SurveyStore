using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectKitHandler : ICommandHandler<CollectKit>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitRepository _kitRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;

        public CollectKitHandler(IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock,
            IKitRepository kitRepository)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
            _kitRepository = kitRepository;
        }

        public async Task HandleAsync(CollectKit command)
        {
            var surveyor = await _surveyorRepository.GetByIdAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var kit = await _kitRepository.GetByIdAsync(command.KitId);
            if (kit is null)
            {
                throw new KitNotFoundException(command.KitId);
            }

            var kitCollection = await _kitCollectionRepository
                .GetAsPredicateExpression(new IsFreeKitCollection(command.KitId));
            if (kitCollection is null)
            {
                throw new FreeKitCollectionNotFoundException(command.KitId);
            }
          
            kitCollection.Collect(surveyor, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kitCollection);
        }
    }
}
