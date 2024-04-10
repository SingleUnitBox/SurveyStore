using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Users.Core.Commands;
using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Modules.Users.Core.Services;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Contexts;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class AccountController : BaseController
    {
        public const string Policy = "users";
        private readonly IAccountService _accountService;
        private readonly IContext _context;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICommandHandler<SignIn, Shared.Abstractions.Auth.JsonWebToken> _jsonCommandHandler;

        public AccountController(IAccountService accountService,
            IContext context,
            ICommandDispatcher commandDispatcher,
            ICommandHandler<SignIn, Shared.Abstractions.Auth.JsonWebToken> jsonCommandHandler)
        {
            _accountService = accountService;
            _context = context;
            _commandDispatcher = commandDispatcher;
            _jsonCommandHandler = jsonCommandHandler;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("me")]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var userId = _context.Identity.Id;
            return OkOrNotFound(await _accountService.GetAsync(userId));
        }

        [AllowAnonymous]
        [ProducesResponseType(204)]
        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(SignUp command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [HttpPost("sign-in")]
        public async Task<ActionResult<Shared.Abstractions.Auth.JsonWebToken>> SignIn(SignIn command)
        {
            var token = await _jsonCommandHandler.HandleAsync(command);
            return Ok(token);
        }
    }
}
