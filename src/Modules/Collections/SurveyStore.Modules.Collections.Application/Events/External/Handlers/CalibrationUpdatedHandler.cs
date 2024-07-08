using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Time;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class CalibrationUpdatedHandler : IEventHandler<CalibrationUpdated>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IClock _clock;
        private readonly ICollectionPolicy _collectionPolicy;

        public CalibrationUpdatedHandler(ICollectionRepository collectionRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            ICollectionPolicy collectionPolicy)
        {
            _collectionRepository = collectionRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _collectionPolicy = collectionPolicy;
        }

        public async Task HandleAsync(CalibrationUpdated @event)
        {
            var collection = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsFreeCollection(@event.SurveyEquipmentId) | new IsOpenCollectionById(@event.SurveyEquipmentId));
            if (collection is null)
            {
                return;
            }

            if (_collectionPolicy.IsCalibrationDue(collection, @event.CalibrationStatus))
            {
                collection.ReturnForCalibration(collection.CollectionStoreId, _clock.Current());
            }

            await _collectionRepository.UpdateAsync(collection);
        }
    }
}