using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Core.Exceptions;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectSurveyEquipmentHandler : ICommandHandler<CollectSurveyEquipment>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;

        public CollectSurveyEquipmentHandler(ICollectionRepository collectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock)
        {
            _collectionRepository = collectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
        }

        public async Task HandleAsync(CollectSurveyEquipment command)
        {
            var surveyor = await _surveyorRepository.GetAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is null)
            {
                throw new CollectionNotFoundException(command.SurveyEquipmentId);
            }

            collection.Collect(surveyor, _clock.Current());
            await _collectionRepository.UpdateAsync(collection);
        }
    }
}
