using Microsoft.AspNetCore.Identity;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Core.Events;
using SurveyStore.Modules.Users.Core.Exceptions;
using SurveyStore.Modules.Users.Core.Repositories;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Commands.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn, JsonWebToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthManager _authManager;
        private readonly IMessageBroker _messageBroker;

        public SignInHandler(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IAuthManager authManager,
            IMessageBroker messageBroker)
        {
            _userRepository = userRepository;
            _authManager = authManager;
            _passwordHasher = passwordHasher;
            _messageBroker = messageBroker;
        }
        public async Task<JsonWebToken> HandleAsync(SignIn command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user is null)
            {
                throw new InvalidCredentialsException();
            }

            var passwordVerified = _passwordHasher.VerifyHashedPassword(default,
                user.Password, command.Password) == PasswordVerificationResult.Success;
            if (!passwordVerified)
            {
                throw new InvalidCredentialsException();
            }

            var jwt = _authManager.CreateToken(user.Id.ToString("N"), user.Role, claims: user.Claims);
            jwt.Email = user.Email;

            await _messageBroker.PublishAsync(new SignedIn(user.Id, user.Email));
            return jwt;
        }
    }
}
