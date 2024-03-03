using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Modules.Stores.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IStoreRepository _storeRepository;
        public StoreService_DeleteAsync_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _storeService = new StoreService(_storeRepository);
        }
    }
}
