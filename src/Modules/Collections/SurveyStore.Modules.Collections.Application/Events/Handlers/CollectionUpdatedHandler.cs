﻿using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.Handlers
{
    public class CollectionUpdatedHandler : IEventHandler<CollectionUpdated>
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionUpdatedHandler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(CollectionUpdated @event)
        {
            var surveyEquipmentId = new AggregateId(@event.SurveyEquipmentId);
            var collection = await _collectionRepository.GetFreeBySurveyEquipmentAsync(surveyEquipmentId);
            if (collection is null)
            {
                collection = Collection.Create(Guid.NewGuid(), surveyEquipmentId);
                collection.ChangeCollectionStoreId(@event.StoreId);
                await _collectionRepository.AddAsync(collection);
            }
            else
            {
                collection.ChangeCollectionStoreId(@event.StoreId);
                await _collectionRepository.UpdateAsync(collection);
            }           
        }
    }
}
