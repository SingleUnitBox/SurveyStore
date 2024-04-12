using Microsoft.AspNetCore.Identity;
using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Core.Events;
using SurveyStore.Modules.Users.Core.Exceptions;
using SurveyStore.Modules.Users.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClock _clock;
        private readonly IMessageBroker _messageBroker;

        public SignUpHandler(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IClock clock,
            IMessageBroker messageBroker)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _clock = clock;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(SignUp command)
        {
            var email = command.Email.ToLowerInvariant();
            var user = await _userRepository.GetByEmailAsync(email);
            if (user is not null)
            {
                throw new EmailInUseException(email);
            }

            var hashedPassword = _passwordHasher.HashPassword(default, command.Password);
            user = new User()
            {
                Id = command.Id,
                Email = command.Email,
                Password = hashedPassword,
                Role = command.Role?.ToLowerInvariant() ?? "user",
                IsActive = true,
                CreatedAt = _clock.Current(),
                Claims = command.Claims ?? new Dictionary<string, IEnumerable<string>>()
            };

            await _userRepository.AddAsync(user);
            await _messageBroker.PublishAsync(new UserCreated(user.Id, user.Email));
         }
    }
}
