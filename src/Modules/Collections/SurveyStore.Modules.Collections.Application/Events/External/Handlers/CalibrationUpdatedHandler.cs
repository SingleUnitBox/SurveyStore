﻿using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
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
        private readonly IMessageBroker _messageBroker;

        public CalibrationUpdatedHandler(ICollectionRepository collectionRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            ICollectionPolicy collectionPolicy,
            IMessageBroker messageBroker)
        {
            _collectionRepository = collectionRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _collectionPolicy = collectionPolicy;
            _messageBroker = messageBroker;
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
            await _messageBroker.PublishAsync(new CollectionReturnedDueCalibration(collection.SurveyEquipmentId, collection.ReturnStoreId));
        }
    }
}