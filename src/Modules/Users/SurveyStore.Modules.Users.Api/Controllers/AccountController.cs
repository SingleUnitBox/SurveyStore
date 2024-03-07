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

namespace SurveyStore.Modules.Users.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        //private readonly HttpContext _httpContext;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            //_httpContext = httpContext;
        }

        //[HttpGet("me")]
        //public async Task<ActionResult<AccountDto>> Get()
        //{
        //    var userId = Guid.Parse(_httpContext.User?.Identity.Name);
        //    return OkOrNotFound(await _accountService.GetAsync(userId));
        //}
            

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
