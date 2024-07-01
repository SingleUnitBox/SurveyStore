using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Collections.Domain.Collections.Consts;
using SurveyStore.Modules.Collections.Domain.Collections.DomainServices;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Exceptions;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Time;
using SurveyStore.Shared.Abstractions.Types;
using SurveyStore.Shared.Infrastructure.Time;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace SurveyStore.Modules.Collections.Tests.Unit.DomainServices
{
    public class CollectionService_Collect_Tests
    {
        private void Act(IEnumerable<Collection> openCollections, Collection toBeCollected,
            Surveyor surveyor, Date collectedAt) => CollectionService
            .Collect(openCollections, toBeCollected, surveyor, collectedAt);

        [Fact]
        public void given_limited_survey_equipment_type_collect_should_fail_producing_cannot_collect_survey_equipment_exception()
        {
            _kitConstOptions.LimitedSurveyEquipmentTypes = new string[] { SurveyEquipmentTypes.TotalStation };
            CollectionService = new CollectionService(_kitConstOptions);
            var surveyEquipment = GetSurveyEquipment();
            var openCollection = CreateCollectionWithSurveyEquipment(surveyEquipment);
            var openCollections = new List<Collection>
            {
                openCollection,
            };
            var surveyEquipmentToBeCollected = GetSurveyEquipment();
            var toBeCollected = CreateCollectionWithSurveyEquipment(surveyEquipmentToBeCollected);
            var surveyor = GetSurveyor();
            var collectedAt = _clock.Current();

            var exception = Record.Exception(() => Act(openCollections, toBeCollected, surveyor, collectedAt));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<CannotCollectSurveyEquipmentException>();

        }

        [Fact]
        public void given_valid_input_collect_should_succeed_adding_surveyor_and_collected_at()
        {
            CollectionService = new CollectionService(_kitConstOptions);
            var openCollections = new List<Collection>();
            var surveyEquipment = GetSurveyEquipment();
            var toBeCollected = CreateCollectionWithSurveyEquipment(surveyEquipment);
            toBeCollected.AssignStore(Guid.NewGuid());
            var surveyor = GetSurveyor();
            var collectedAt = new Date(_clock.Current());

            Act(openCollections, toBeCollected, surveyor, collectedAt);

            toBeCollected.Surveyor.ShouldBe(surveyor);
            toBeCollected.CollectedAt.ShouldBeEquivalentTo(collectedAt);
        }

        public ICollectionService CollectionService { get; set; }
        private readonly KitConstOptions _kitConstOptions;
        private readonly IClock _clock;

        public CollectionService_Collect_Tests()
        {
            _kitConstOptions = new KitConstOptions();
            _clock = new ClockUtc();
        }

        private SurveyEquipment GetSurveyEquipment()
            => SurveyEquipment.Create(Guid.NewGuid(), "ABC123", "Trimble", "S5", SurveyEquipmentTypes.TotalStation);

        private Surveyor GetSurveyor()
            => Surveyor.Create(Guid.NewGuid(), "John", "Doe");

        private Collection CreateCollectionWithSurveyEquipment(SurveyEquipment surveyEquipment)
        {
            var collection = Collection.Create(Guid.NewGuid(), surveyEquipment.Id);
            var surveyEquipmentField = typeof(Collection)
                .GetProperty("SurveyEquipment");
            surveyEquipmentField.SetValue(collection, surveyEquipment);

            return collection;
        }
    }
}
 