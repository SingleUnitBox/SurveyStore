using NSubstitute;
using Shouldly;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Core.Exceptions;
using SurveyStore.Modules.Stores.Core.Repositories;
using SurveyStore.Modules.Stores.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Events;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Unit.Services
{
    public class StoreService_UpdateAsync_Tests
    {
        private Task Act(StoreDto storeDto) => _storeService.UpdateAsync(storeDto);

        [Fact]
        public async Task given_non_existing_store_update_async_should_fail()
        {
            var storeDto = new StoreDto
            {
                Id = Guid.NewGuid()
            };

            _storeRepository.GetAsync(storeDto.Id).Returns(Task.FromResult<Store>(null));

            var exception = await Record.ExceptionAsync(() => Act(storeDto));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<StoreNotFoundException>();
        }

        [Fact]
        public async Task given_invalid_operation_hours_update_async_should_fail()
        {
            var storeDto = new StoreDto
            {
                Id = Guid.NewGuid(),
                OpeningTime = new DateTime(2024, 1, 1, 08, 0, 0),
                ClosingTime = new DateTime(2024, 1, 1, 06, 0, 0),
            };
            _storeRepository.GetAsync(storeDto.Id).Returns(new Store { Id = storeDto.Id });

            var exception = await Record.ExceptionAsync(() => Act(storeDto));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidOperationTimeException>();
        }

        [Fact]
        public async Task given_valid_data_update_async_should_succeed()
        {
            var storeDto = new StoreDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                Location = "Test Location",
                OpeningTime = new DateTime(2024, 1, 1, 8, 0, 0),
                ClosingTime = new DateTime(2024, 1, 1, 17, 0, 0),
            };
            var store = new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Location = storeDto.Location,
                OpeningTime = storeDto.OpeningTime,
                ClosingTime = storeDto.ClosingTime,
            };
            _storeRepository.GetAsync(storeDto.Id).Returns(store);

            await Act(storeDto);

            await _storeRepository.Received(1)
                .UpdateAsync(Arg.Is<Store>(x => x.Id == store.Id));
        }

        private readonly IStoreService _storeService;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IStoreRepository _storeRepository;

        public StoreService_UpdateAsync_Tests()
        {
            _storeRepository = Substitute.For<IStoreRepository>();
            _eventDispatcher = Substitute.For<IEventDispatcher>();
            _storeService = new StoreService(_storeRepository, _eventDispatcher);
        }
    }
}
