using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.ValueObjects;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class CollectSurveyEquipmentHandler : ICommandHandler<CollectSurveyEquipment>
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IKitRepository _kitRepository;
        private readonly ICollectionService _collectionService;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public CollectSurveyEquipmentHandler(ICollectionRepository collectionRepository,
            IKitCollectionRepository kitCollectionRepository,
            ISurveyorRepository surveyorRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository,
            IKitRepository kitRepository,
            ICollectionService collectionService,
            IEventMapper eventMapper,
            IMessageBroker messageBroker)
        {
            _collectionRepository = collectionRepository;
            _kitCollectionRepository = kitCollectionRepository;
            _surveyorRepository = surveyorRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _kitRepository = kitRepository;
            _collectionService = collectionService;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
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
                throw new FreeCollectionNotFoundException(command.SurveyEquipmentId);
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var openCollections = await _collectionRepository.BrowseOpenCollectionsBySurveyorIdAsync(command.SurveyorId);
            var surveyEquipmentTypes = await GetSurveyEquipmentTypes(openCollections);
            

            _collectionService.CanBeCollected(surveyEquipmentTypes, surveyEquipment.Type);
            var now = _clock.Current();
            _collectionService.Collect(collection, surveyor, now);
            await _collectionRepository.UpdateAsync(collection);

            var events = _eventMapper.MapAll(collection.Events);
            await _messageBroker.PublishAsync(events.ToArray());

            //var freeKitCollections = await _kitCollectionRepository.BrowseFreeKitCollectionsAsync();
            //
            //var kitSet = _collectionService.CollectTraverseSet(freeKitCollections, surveyor, collection, now);


            //await _kitCollectionRepository.UpdateRangeAsync(freeKitCollections);

            //await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            //foreach (var kit in kitSet)
            //{
            //    kit.UnassignStore();
            //}
            //await _kitRepository.UpdateRangeAsync(kitSet);
        }

        private async Task<IEnumerable<SurveyEquipmentType>> GetSurveyEquipmentTypes(IEnumerable<Collection> openCollections)
        {
            var tasks = openCollections.Select(c => _surveyEquipmentRepository.GetByIdAsync(c.SurveyEquipmentId.Value));
            var result = await Task.WhenAll(tasks);
            var surveyEquipmentTypes = result.Select(s => s.Type);

            return surveyEquipmentTypes;
        }
    }
}
