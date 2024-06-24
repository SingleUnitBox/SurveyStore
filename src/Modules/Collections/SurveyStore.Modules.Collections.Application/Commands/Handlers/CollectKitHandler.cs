using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectKitHandler : ICommandHandler<CollectKit>
    {
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;

        public CollectKitHandler(IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock)
        {
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
        }

        public async Task HandleAsync(CollectKit command)
        {
            var kitCollection = await _kitCollectionRepository.GetFreeByKitAsync(command.KitId);
            if (kitCollection is null)
            {
                throw new FreeKitCollectionNotFoundException(command.KitId);
            }

            var surveyor = await _surveyorRepository.GetByIdAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            kitCollection.Collect(surveyor, _clock.Current());
            await _kitCollectionRepository.UpdateAsync(kitCollection);
        }
    }
}
