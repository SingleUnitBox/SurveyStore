using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Modules.Users.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SurveyStore.Shared.Abstractions.Contexts;

namespace SurveyStore.Modules.Users.Api.Controllers
{
    public class AccountController : BaseController
    {
        private const string Policy = "users";
        private readonly IAccountService _accountService;
        private readonly IContext _context;

        public AccountController(IAccountService accountService,
            IContext context)
        {
            _accountService = accountService;
            _context = context;
        }

        [Authorize(Policy = Policy)]
        [HttpGet("me")]
        public async Task<ActionResult<AccountDto>> Get()
        {
            var userId = _context.Identity.Id;
            return OkOrNotFound(await _accountService.GetAsync(userId));
        }


        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp(SignUpDto signUpDto)
        {
            await _accountService.SignUpAsync(signUpDto);
            return NoContent();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<JsonWebToken>> SignIn(SignInDto signInDto)
        {
            var token = await _accountService.SignInAsync(signInDto);
            return Ok(token);
        }
    }
}
