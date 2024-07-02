using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Application.Events;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Moduless;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreHandler : ICommandHandler<AssignStore>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ICalibrationsApiClient _calibrationsApiClient;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        private readonly IEventDispatcher _eventDispatcher;

        public AssignStoreHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker,
            ICalibrationsApiClient calibrationsApiClient,
            ICollectionRepository collectionRepository,
            IEventDispatcher eventDispatcher)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _calibrationsApiClient = calibrationsApiClient;
            _collectionRepository = collectionRepository;
            _eventDispatcher = eventDispatcher;
        }

        public async Task HandleAsync(AssignStore command)
        {
            //should I check different module???
            var calibration = await _calibrationsApiClient.GetCalibrationAsync(command.SurveyEquipmentId);
            if (calibration?.CalibrationStatus.ToString() == "ToBeReturnForCalibration")
            {
                throw new SurveyEquipmentToBeCalibratedException(command.SurveyEquipmentId);
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var store = await _storeRepository.GetByIdAsync(command.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreId);
            }

            var collection = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsFreeCollection(surveyEquipment.Id));
            if (collection is not null)
            {
                collection.AssignStore(store.Id);
                await _collectionRepository.UpdateAsync(collection);
            }
            else
            {
                collection = await _collectionRepository.GetAsPredicateExpressionAsync(new IsOpenCollectionById(surveyEquipment.Id));
                if (collection is not null)
                {
                    throw new CannotAssignStoreException(surveyEquipment.Id);
                }

                collection = Collection.Create(Guid.NewGuid(), surveyEquipment.Id);
                collection.AssignStore(store.Id);
                await _collectionRepository.AddAsync(collection);
            }

            await _messageBroker.PublishAsync(new CollectionCreated(collection.Id, collection.SurveyEquipmentId));
        }
    }
}
