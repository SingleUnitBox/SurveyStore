using Shouldly;
using SurveyStore.Modules.Collections.Domain.Collections.DomainEvents;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Linq;
using Xunit;

namespace SurveyStore.Modules.Collections.Tests.Unit.Entities
{
    public class SurveyEquipment_AssignStore_Tests
    {
        private void Act(Guid storeId) => _surveyEquipment.AssignStore(storeId);

        [Fact]
        public void given_same_storeId_as_existing_assign_store_should_return()
        {
            Act(_store.Id);
            Act(_store.Id);

            _surveyEquipment.StoreId.ShouldBe(_store.Id);
            _surveyEquipment.Events.Count().ShouldBe(1);
        }

        [Fact]
        public void given_different_storeId_assign_store_should_succeed()
        {
            Act(Guid.NewGuid());

            _surveyEquipment.StoreId.ShouldNotBe(_store.Id);
            _surveyEquipment.Events.Count().ShouldBe(1);
            _surveyEquipment.Events.FirstOrDefault().ShouldBeOfType<StoreAssigned>();
        }

        public SurveyEquipment_AssignStore_Tests()
        {
            _surveyEquipment = SurveyEquipment.Create(Guid.NewGuid(), "ABC123", "Trimble", "S5",
                SurveyEquipmentTypes.TotalStation);
            _store = Store.Create(Guid.NewGuid(), "TBH");
        }

        private readonly SurveyEquipment _surveyEquipment;
        private readonly Store _store;
    }
}
