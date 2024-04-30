using Shouldly;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using Xunit;

namespace SurveyStore.Modules.Collections.Tests.Unit.Entities
{
    public class Collection_Collect_Tests
    {
        private void Act(Surveyor surveyor, DateTime collectedAt) => _collection.Collect(surveyor, collectedAt);

        [Fact]
        public void missing_collection_store_id_collect_should_fail()
        {
            var surveyor = GetSurveyor();
            var collectedAt = DateTime.UtcNow;

            var exception = Record.Exception(() => Act(surveyor, collectedAt));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<SurveyEquipmentNotFoundInStoreException>();
        }

        [Fact]
        public void given_valid_input_collect_should_succeed()
        {
            var surveyor = GetSurveyor();
            var collectedAt = DateTime.UtcNow;
            var collectionStoreId = new StoreId(Guid.NewGuid());
            _collection.ChangeCollectionStoreId(collectionStoreId);

            var exception = Record.Exception(() => Act(surveyor, collectedAt));

            exception.ShouldBeNull();
            _collection.CollectionStoreId.ShouldBeEquivalentTo(collectionStoreId);
            _collection.Surveyor.ShouldBeEquivalentTo(surveyor);
            _collection.CollectedAt.ShouldBeEquivalentTo(collectedAt);
        }

        private readonly Collection _collection;
        public Collection_Collect_Tests()
        {
            _collection = Collection.Create(Guid.NewGuid(), Guid.NewGuid());
        }

        private static Surveyor GetSurveyor() => Surveyor.Create(Guid.NewGuid(), "John", "Doe");
    }
}
