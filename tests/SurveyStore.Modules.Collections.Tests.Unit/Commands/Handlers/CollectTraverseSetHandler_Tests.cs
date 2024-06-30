using Microsoft.OpenApi.Validations;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Modules.Collections.Application.Commands.Handlers;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel;
using SurveyStore.Shared.Abstractions.Specification;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Abstractions.Types;
using SurveyStore.Shared.Infrastructure.Time;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xunit;

namespace SurveyStore.Modules.Collections.Tests.Unit.Commands.Handlers
{
    public class CollectTraverseSetHandler_Tests
    {
        private Task Act(CollectTraverseSet command) => _commandHandler.HandleAsync(command);

        [Fact]
        public async Task given_invalid_surveyor_collect_should_fail_producing_surveyor_not_found_exception()
        {
            var surveyEquipment = GetSurveyEquipment(Guid.NewGuid());
            var surveyor = GetSurveyor(Guid.NewGuid());
            var command = new CollectTraverseSet(surveyEquipment.Id, surveyor.Id);
            _surveyorRepository.GetByIdAsync(surveyor.Id).Returns(Task.FromResult<Surveyor>(null));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<SurveyorNotFoundException>();
        }

        [Fact]
        public async Task given_invalid_surveyEquipment_collect_should_fail_producing_survey_equipment_not_found_exception()
        {
            var surveyEquipment = GetSurveyEquipment(Guid.NewGuid());
            var surveyor = GetSurveyor(Guid.NewGuid());
            var command = new CollectTraverseSet(surveyEquipment.Id, surveyor.Id);
            _surveyEquipmentRepository.GetByIdAsync(surveyEquipment.Id).Returns(Task.FromResult<SurveyEquipment>(null));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<SurveyorNotFoundException>();
        }

        [Fact]
        public async Task given_non_free_collection_collect_should_fail_producing_free_collection_not_found_exception()
        {
            var surveyEquipment = GetSurveyEquipment(Guid.NewGuid());
            var surveyor = GetSurveyor(Guid.NewGuid());
            var collection = GetCollection(Guid.NewGuid(), surveyEquipment.Id);
            var command = new CollectTraverseSet(surveyEquipment.Id, surveyor.Id);
            _collectionRepository.GetAsPredicateExpressionAsync(Arg.Any<Specification<Collection>>())
                .Returns(Task.FromResult<Collection>(null));
            
            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldNotBeOfType<FreeKitCollectionNotFoundException>();
        }

        [Fact]
        public async Task given_valid_input_collect_should_succeed_persisting_collection()
        {
            var surveyEquipment = GetSurveyEquipment(Guid.NewGuid());
            _surveyEquipmentRepository.GetByIdAsync(surveyEquipment.Id).Returns(surveyEquipment);
            var surveyor = GetSurveyor(Guid.NewGuid());
            _surveyorRepository.GetByIdAsync(surveyor.Id).Returns(surveyor);
            var collection = GetCollection(Guid.NewGuid(), surveyEquipment.Id);
            var command = new CollectTraverseSet(surveyEquipment.Id, surveyor.Id);
            _collectionRepository.GetAsPredicateExpressionAsync(Arg.Any<Specification<Collection>>())
                .Returns(Task.FromResult<Collection>(collection));
            var openCollections = new List<Collection>();
            _collectionRepository.BrowseAsPredicateExpressionAsync(Arg.Any<Specification<Collection>>())
                .Returns(Task.FromResult<IEnumerable<Collection>>(openCollections));
            var openKitCollections = new List<KitCollection>
            {
                KitCollection.Create(Guid.NewGuid(), Guid.NewGuid()),
                KitCollection.Create(Guid.NewGuid(), Guid.NewGuid()),
                KitCollection.Create(Guid.NewGuid(), Guid.NewGuid())
            };
            _kitCollectionRepository.BrowseAsPredicateExpression(Arg.Any<Specification<KitCollection>>())
                .Returns(Task.FromResult<IEnumerable<KitCollection>>(openKitCollections));


            await Act(command);

            await _collectionRepository.Received(1).UpdateAsync(collection);
        }

        private readonly ICommandHandler<CollectTraverseSet> _commandHandler;
        private readonly ICollectionRepository _collectionRepository; 
        private readonly IKitCollectionRepository _kitCollectionRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IClock _clock;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly ICollectionService _collectionService;
        private readonly IKitCollectionService _kitCollectionService;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public CollectTraverseSetHandler_Tests()
        {
            _collectionRepository = Substitute.For<ICollectionRepository>();
            _kitCollectionRepository = Substitute.For<IKitCollectionRepository>();
            _surveyorRepository = Substitute.For<ISurveyorRepository>();
            _clock = new ClockUtc();
            _surveyEquipmentRepository = Substitute.For<ISurveyEquipmentRepository>();
            _collectionService = Substitute.For<ICollectionService>();
            _kitCollectionService = Substitute.For<IKitCollectionService>();
            _domainEventDispatcher = Substitute.For<IDomainEventDispatcher>();
            _commandHandler = new CollectTraverseSetHandler(_collectionRepository, _kitCollectionRepository,
                _surveyorRepository, _clock, _surveyEquipmentRepository,
                _collectionService, _kitCollectionService, _domainEventDispatcher);
        }

        private SurveyEquipment GetSurveyEquipment(Guid surveyEquipmentId)
        {
            var surveyEquipment = SurveyEquipment
                .Create(surveyEquipmentId, "ABC123", "Trimble", "S5", SurveyEquipmentTypes.TotalStation);

            return surveyEquipment;
        }

        private Surveyor GetSurveyor(Guid surveyorId)
        {
            var surveyor = Surveyor.Create(surveyorId, "John", "Doe");

            return surveyor;
        }

        private Collection GetCollection(Guid collectionId, Guid surveyequipmentId)
        {
            var collection = Collection.Create(collectionId, surveyequipmentId);

            return collection;
        }
    }
}
