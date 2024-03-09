﻿using Shouldly;
using SurveyStore.Modules.Users.Core.DAL;
using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Tests.Integration.Commons;
using SurveyStore.Shared.Tests;
using SurveyStore.Shared.Infrastructure.Time;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace SurveyStore.Modules.Users.Tests.Integration.Controllers
{
    [Collection("integration")]
    public class AccountControllerTests : IClassFixture<TestApplicationFactory>, IClassFixture<TestUsersDbContext>, IClassFixture<TestClock>
    {
        [Fact]
        public async Task given_email_in_use_sign_up_async_should_fail()
        {
            var signUpDto = new SignUpDto
            {
                Id = Guid.NewGuid(),
                Email = "test@gmail.com",
                Password = "secret",
            };
            var user = new User
            {
                Id = signUpDto.Id,
                Email = signUpDto.Email,
                Password = signUpDto.Password,
                Role = signUpDto.Role?.ToLowerInvariant() ?? "user",
                IsActive = true,
                CreatedAt = _clock.Current(),
                Claims = signUpDto.Claims ?? new Dictionary<string, IEnumerable<string>>()
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var response = await _httpClient.PostAsJsonAsync(Path, signUpDto);

            response.IsSuccessStatusCode.ShouldBeFalse();
        }

        private const string Path = "users-module/account";
        private readonly HttpClient _httpClient;
        private readonly UsersDbContext _dbContext;
        private readonly ClockUtc _clock;

        public AccountControllerTests(TestApplicationFactory factory, TestUsersDbContext dbContext,
            TestClock clock)
        {
            _httpClient = factory.CreateClient();
            _dbContext = dbContext.DbContext;
            _clock = clock.Clock;
        }
    }
}
