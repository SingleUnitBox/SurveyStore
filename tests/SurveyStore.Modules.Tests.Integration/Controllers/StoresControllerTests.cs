using Microsoft.EntityFrameworkCore;
using Shouldly;
using SurveyStore.Modules.Stores.Core.DAL;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Entities;
using SurveyStore.Modules.Stores.Tests.Integration.Common;
using SurveyStore.Shared.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace SurveyStore.Modules.Stores.Tests.Integration.Controllers
{
    [Collection("integration")]
    public class StoresControllerTests : IClassFixture<TestApplicationFactory>, IClassFixture<TestStoresDbContext>
    {
        [Fact]
        public async Task browse_async_return_ok_status_code_with_stores_collection()
        {
            var store = CreateStore();
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"{Path}");

            response.IsSuccessStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var storesDto = await response.Content.ReadFromJsonAsync<IEnumerable<StoreDto>>();
            storesDto.ShouldNotBeNull();
            storesDto.Count().ShouldBe(1);
        }

        [Fact]
        public async Task get_async_for_invalid_id_return_not_found_status_code()
        {
            var id = Guid.NewGuid();

            var response = await _httpClient.GetAsync($"{Path}/{id}");

            response.IsSuccessStatusCode.ShouldBeFalse();
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task get_async_for_valid_id_return_ok_status_code_with_store()
        {
            var store = CreateStore();
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();

            var response = await _httpClient.GetAsync($"{Path}/{store.Id}");

            response.IsSuccessStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var storeDto = await response.Content?.ReadFromJsonAsync<StoreDto>();
            storeDto.Id.ShouldBe(store.Id);
        }

        [Fact]
        public async Task delete_async_for_valid_id_succeed_and_return_no_content_status_code()
        {
            var store = CreateStore();
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
            var claims = new Dictionary<string, IEnumerable<string>>
            {
                {"permissions", new[] {"stores"}}
            };

            Autenticate(Guid.NewGuid(), claims);
            var response = await _httpClient.DeleteAsync($"{Path}/{store.Id}");

            response.IsSuccessStatusCode.ShouldBeTrue();
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        private const string Path = "stores-module/stores";
        private readonly HttpClient _httpClient;
        private readonly StoresDbContext _dbContext;

        public StoresControllerTests(TestApplicationFactory factory, TestStoresDbContext dbContext)
        {
            _httpClient = factory.CreateClient();
            _dbContext = dbContext.DbContext;
        }

        private void Autenticate(Guid userId, IDictionary<string, IEnumerable<string>> claims = null)
        {
            var jwt = AuthHelper.GenerateJwt(userId.ToString(), claims);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }

        private static Store CreateStore() =>
            new()
            {
                Id = Guid.NewGuid(),
                Name = "test name",
                Location = "test location",
                OpeningTime = new DateTime(2024, 1, 1, 8, 0, 0),
                ClosingTime = new DateTime(2024, 1, 1, 17, 0, 0),
            };

    }
}
