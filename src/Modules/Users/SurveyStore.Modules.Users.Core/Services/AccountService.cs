using Microsoft.AspNetCore.Identity;
using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Core.Events;
using SurveyStore.Modules.Users.Core.Exceptions;
using SurveyStore.Modules.Users.Core.Repositories;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClock _clock;
        private readonly IAuthManager _authManager;
        private readonly IMessageBroker _messageBroker;

        public AccountService(IUserRepository userRepository, IClock clock,
            IPasswordHasher<User> passwordHasher, IAuthManager authManager,
            IMessageBroker messageBroker)
        {
            _userRepository = userRepository;
            _clock = clock;
            _passwordHasher = passwordHasher;
            _authManager = authManager;
            _messageBroker = messageBroker;
        }

        public async Task<AccountDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
            {
                return null;
            }

            return new AccountDto
            {
                Id = id,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                Claims = user.Claims
            };
        }

        //public async Task<JsonWebToken> SignInAsync(SignInDto signInDto)
        //{
        //    var user = await _userRepository.GetByEmailAsync(signInDto.Email);
        //    if (user is null)
        //    {
        //        throw new InvalidCredentialsException();
        //    }

        //    var passwordVerified = _passwordHasher.VerifyHashedPassword(default,
        //        user.Password, signInDto.Password) == PasswordVerificationResult.Success;
        //    if (!passwordVerified)
        //    {
        //        throw new InvalidCredentialsException();
        //    }

        //    var jwt = _authManager.CreateToken(user.Id.ToString("N"), user.Role, claims: user.Claims);
        //    jwt.Email = user.Email;

        //    return jwt;
        //}

        //public async Task SignUpAsync(SignUpDto signUpDto)
        //{
        //    signUpDto.Id = Guid.NewGuid();
        //    var email = signUpDto.Email.ToLowerInvariant();
        //    var user = await _userRepository.GetByEmailAsync(email);
        //    if (user is not null)
        //    {
        //        throw new EmailInUseException(email);
        //    }

        //    var hashedPassword = _passwordHasher.HashPassword(default, signUpDto.Password);

        //    user = new User
        //    {
        //        Id = signUpDto.Id,
        //        Email = email,
        //        Password = hashedPassword,
        //        Role = signUpDto.Role?.ToLowerInvariant() ?? "user",
        //        IsActive = true,
        //        CreatedAt = _clock.Current(),
        //        Claims = signUpDto.Claims ?? new Dictionary<string, IEnumerable<string>>()
        //    };

        //    await _userRepository.AddAsync(user);
        //    await _messageBroker.PublishAsync(new UserCreated(user.Id, user.Email));
        //}
    }
}
