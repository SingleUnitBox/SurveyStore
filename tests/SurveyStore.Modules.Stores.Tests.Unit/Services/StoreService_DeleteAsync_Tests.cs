using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Modules.Stores.Core.Services;
using SurveyStore.Shared.Abstractions.Events;
using System;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Messaging;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Services
{
    public class StoreService_DeleteAsync_Tests
    {
        private Task Act(Guid id) => _storeService.DeleteAsync(id);

        [Fact]
        public async Task given_non_existing_store_delete_async_should_fail()
        {
            var id = Guid.NewGuid();
            _storeRepository.GetAsync(id).Returns(Task.FromResult<Store>(null));

            var exception = await Record.ExceptionAsync(() => Act(id));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreNotFoundException>();
        }

        [Fact]
        public async Task given_existing_store_delete_async_should_succeed()
        {
            var store = new Store
            {
                Id = Guid.NewGuid(),
            };
            _storeRepository.GetAsync(store.Id).Returns(Task.FromResult<Store>(store));

            await Act(store.Id);

            await _storeRepository.Received(1)
                .DeleteAsync(Arg.Is<Store>(s => s.Id == store.Id));
        }

        private readonly IStoreService _storeService;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IStoreRepository _storeRepository;
        private readonly IMessageBroker _messageBroker;
        public StoreService_DeleteAsync_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _eventDispatcher = Substitute.For<IEventDispatcher>();
            _messageBroker = Substitute.For<IMessageBroker>();
            _storeService = new StoreService(_storeRepository, _messageBroker);
        }
    }
}
