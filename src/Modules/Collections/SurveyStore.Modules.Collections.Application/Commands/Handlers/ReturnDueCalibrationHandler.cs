using SurveyStore.Modules.Collections.Application.Events;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnDueCalibrationHandler : ICommandHandler<ReturnDueCalibration>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IClock _clock;
        private readonly ICollectionPolicy _collectionPolicy;
        private readonly IMessageBroker _messageBroker;

        public ReturnDueCalibrationHandler(ICollectionRepository collectionRepository,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            IClock clock,
            ICollectionPolicy collectionPolicy,
            IMessageBroker messageBroker)
        {
            _collectionRepository = collectionRepository;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _clock = clock;
            _collectionPolicy = collectionPolicy;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(ReturnDueCalibration command)
        {
            var collection = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsFreeCollection(command.SurveyEquipmentId) | new IsOpenCollectionById(command.SurveyEquipmentId));
            if (collection is null)
            {
                return;
            }

            if (_collectionPolicy.IsCalibrationDue(collection, command.CalibrationStatus))
            {
                collection.ReturnForCalibration(collection.CollectionStoreId, _clock.Current());
            }

            await _collectionRepository.UpdateAsync(collection);
            await _messageBroker.PublishAsync(new CollectionReturnedDueCalibration(collection.SurveyEquipmentId, collection.ReturnStoreId));
        }
    }
}
