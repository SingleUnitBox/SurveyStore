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
            IKitRepository kitRepository,
            IStoreRepository storeRepository,
            ISurveyorRepository surveyorRepository,
            ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository,
            ICollectionPolicy collectionPolicy,
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
            var surveyEquipment = await GetSurveyEquipmentAsync(command.SurveyorId);
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
                var kitType = isFull.kitCollection.FirstOrDefault().Kit.Type;
                var requiredAmount = kitType == KitTypes.Tripod
                    ? KitConstants.TripodRequiredAmount
                    : KitConstants.PrismRequiredAmount;
                var actualAmount = isFull.kitCollection.Count();
                throw new IncompleteTraverseSetException(kitType, requiredAmount, actualAmount);
            }

            var now = _clock.Current();
            collection.Return(command.ReturnStoreId, now);
            await _collectionRepository.UpdateAsync(collection);

            surveyEquipment.AssignStore(command.ReturnStoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            foreach (var kitCollection in isFull.kitCollection)
            {
                kitCollection.Return(command.ReturnStoreId, now);
            }
            await _kitCollectionRepository.UpdateRangeAsync(isFull.kitCollection);

            var kit = isFull.kitCollection.Select(k => k.Kit);
            foreach (var k in kit)
            {
                k.AssignStore(command.ReturnStoreId);
            }
            await _kitRepository.UpdateRangeAsync(kit);
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
    }
}
