using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Policies;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Abstractions.Types;
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
        private readonly ICollectionPolicy _collectionPolicy;
        private readonly IKitRepository _kitRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly IKitCollectionService _kitCollectionService;
        private readonly IClock _clock;

        public ReturnTraverseSetHandler(ISurveyEquipmentRepository surveyEquipmentRepository,           
            IStoreRepository storeRepository,
            ISurveyorRepository surveyorRepository,
            ICollectionRepository collectionRepository,
            ICollectionPolicy collectionPolicy,
            IKitRepository kitRepository,
            IKitCollectionRepository kitCollectionRepository,
            IKitCollectionService kitCollectionService,
            IClock clock)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _storeRepository = storeRepository;
            _surveyorRepository = surveyorRepository;
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _collectionPolicy = collectionPolicy;
            _kitCollectionService = kitCollectionService;
            _clock = clock;
        }

        public async Task HandleAsync(ReturnTraverseSet command)
        {
            var surveyor = await GetSurveyorAsync(command.SurveyorId);
            var store = await GetStoreAsync(command.ReturnStoreId);
            var surveyEquipment = await GetSurveyEquipmentAsync(command.SurveyEquipmentId);
            var collection = await GetOpenCollectionAsync(command.SurveyEquipmentId);

            if (!_collectionPolicy.CanBeReturned(collection, surveyor))
            {
                throw new ReturningOtherCollectionException(collection.Id, surveyor.Id);
            }

            var openKitCollections = await _kitCollectionRepository
                .BrowseOpenKitCollectionsBySurveyorAsync(surveyor.Id);

            var isFull = _kitCollectionService.IsTraverseSetFullForReturn(openKitCollections);
            if (!isFull.isFull)
            {
                var kitType = isFull.kitCollection.First().Kit.Type;
                var requiredAmount = kitType == KitTypes.Tripod
                    ? KitConstants.TripodRequiredAmount
                    : KitConstants.PrismRequiredAmount;
                var actualAmount = isFull.kitCollection.Count();
                throw new IncompleteTraverseSetException(kitType, requiredAmount, actualAmount);
            }

            await ReturnCollectionAsync(collection, command.ReturnStoreId);
            await AssignSurveyEquipmentAsync(surveyEquipment, command.ReturnStoreId);
            await ReturnKitCollectionsAsync(isFull.kitCollection, command.ReturnStoreId);

            var kit = isFull.kitCollection.Select(k => k.Kit);
            await AssignKitAsync(kit, command.ReturnStoreId);
        }

        private async Task<Surveyor> GetSurveyorAsync(Guid surveyorId)
        {
            var surveyor = await _surveyorRepository.GetAsync(surveyorId);
            if (surveyor is null)
            {
                throw new SurveyorNotFoundException(surveyorId);
            }

            return surveyor;
        }

        private async Task<Store> GetStoreAsync(Guid storeId)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            if (store is null)
            {
                throw new StoreNotFoundException(storeId);
            }

            return store;
        }

        private async Task<SurveyEquipment> GetSurveyEquipmentAsync(Guid surveyEquipmentId)
        {
            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(surveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(surveyEquipmentId);
            }

            return surveyEquipment;
        }

        private async Task<Collection> GetOpenCollectionAsync(Guid surveyEquipmentId)
        {
            var collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(surveyEquipmentId);
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

        private async Task AssignSurveyEquipmentAsync(SurveyEquipment surveyEquipment, Guid returnStoreId)
        {
            surveyEquipment.AssignStore(returnStoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
        }

        private async Task AssignKitAsync(IEnumerable<Kit> kit, Guid returnStoreId)
        {
            foreach (var k in kit)
            {
                k.AssignStore(returnStoreId);
            }

            await _kitRepository.UpdateRangeAsync(kit);
        }
    }
}
