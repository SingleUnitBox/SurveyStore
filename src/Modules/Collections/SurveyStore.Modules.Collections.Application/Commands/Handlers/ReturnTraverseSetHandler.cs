using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.KitCollections;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class ReturnTraverseSetHandler : ICommandHandler<ReturnTraverseSet>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;       
        private readonly IStoreRepository _storeRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ICollectionRepository _collectionRepository;       
        private readonly IKitRepository _kitRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitCollectionService _kitCollectionService;
        private readonly IClock _clock;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;
        private readonly KitConstOptions _kitConstOptions;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public ReturnTraverseSetHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            ISurveyorRepository surveyorRepository,
            ICollectionRepository collectionRepository,
            IKitRepository kitRepository,
            IKitCollectionRepository kitCollectionRepository,
            IKitCollectionService kitCollectionService,
            IClock clock,
            IEventMapper eventMapper,
            IMessageBroker messageBroker,
            KitConstOptions kitConstOptions,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _surveyorRepository = surveyorRepository;
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _kitCollectionService = kitCollectionService;
            _clock = clock;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _kitConstOptions = kitConstOptions;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task HandleAsync(ReturnTraverseSet command)
        {
            var surveyor = await GetSurveyor(command.SurveyorId);
            var store = await GetStore(command.ReturnStoreId);
            var surveyEquipment = await GetSurveyEquipment(command.SurveyEquipmentId);
            var collection = await GetOpenCollection(command.SurveyEquipmentId);

            if (collection.Surveyor.Id != surveyor.Id)
            {
                throw new CollectionDoesNotBelongToSurveyorException(collection.Id, surveyor.Id);
            }

            var openKitCollections = await _kitCollectionRepository
                .BrowseAsPredicateExpression(new IsOpenKitCollection() & new IsSurveyorKitCollection(surveyor.Id));

            var kitToBeReturned = _kitCollectionService.GatherTraverseSetForReturn(openKitCollections);

            var now = _clock.Current();
            collection.Return(store.Id, now);
            await _collectionRepository.UpdateAsync(collection);
            await _domainEventDispatcher.DispatchAsync(collection.Events.ToArray());

            foreach (var kit in kitToBeReturned)
            {
                kit.CheckForReturn(store.Id);
            }

            var domainEvents = kitToBeReturned
                .SelectMany(k => k.Events)
                .ToArray();
            await _domainEventDispatcher.DispatchAsync(domainEvents);
        }

        private async Task<Surveyor> GetSurveyor(Guid surveyorId)
        {
            var surveyor = await _surveyorRepository.GetByIdAsync(surveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(surveyorId);
            }

            return surveyor;
        }

        private async Task<Store> GetStore(Guid storeId)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            if (store is null)
            {
                throw new StoreNotFoundException(storeId);
            }

            return store;
        }

        private async Task<SurveyEquipment> GetSurveyEquipment(Guid surveyEquipmentId)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(surveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(surveyEquipmentId);
            }

            return surveyEquipment;
        }

        private async Task<Collection> GetOpenCollection(Guid surveyEquipmentId)
        {
            var collection = await _collectionRepository
                .GetAsPredicateExpressionAsync(new IsOpenCollectionById(surveyEquipmentId));

            if (collection is null)
            {
                throw new OpenCollectionNotFoundException(surveyEquipmentId);
            }

            return collection;
        }

        private async Task ReturnCollectionAsync(Collection collection, Guid returnStoreId)
        {
            var now = _clock.Current();
            collection.Return(returnStoreId, now);
            await _collectionRepository.UpdateAsync(collection);
        }

        private async Task ReturnKitCollectionsAsync(IEnumerable<KitCollection> kitCollections, Guid returnStoreId)
        {
            var now = _clock.Current();
            foreach (var kitCollection in kitCollections)
            {
                kitCollection.Return(returnStoreId, now);
            }

            await _kitCollectionRepository.UpdateRangeAsync(kitCollections);
        }
    }
}
