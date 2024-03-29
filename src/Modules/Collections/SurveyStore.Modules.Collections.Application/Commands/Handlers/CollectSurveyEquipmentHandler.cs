using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Core.Exceptions;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectSurveyEquipmentHandler : ICommandHandler<CollectSurveyEquipment>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;

        public CollectSurveyEquipmentHandler(ICollectionRepository collectionRepository,
            ISurveyorRepository surveyorRepository)
        {
            _collectionRepository = collectionRepository;
            _surveyorRepository = surveyorRepository;
        }

        public async Task HandleAsync(CollectSurveyEquipment command)
        {
            var surveyor = await _surveyorRepository.GetAsync(command.SurveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(command.SurveyorId);
            }

            var collection = await _collectionRepository.GetCurrentBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is null)
            {
                throw new CollectionNotFoundException(command.SurveyEquipmentId);
            }

            collection.MakeCollection(surveyor);
            await _collectionRepository.UpdateAsync(collection);
        }
    }
}
