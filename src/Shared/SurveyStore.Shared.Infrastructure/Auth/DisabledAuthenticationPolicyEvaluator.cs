using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Auth
{
    internal sealed class DisabledAuthenticationPolicyEvaluator : IPolicyEvaluator
    {
        public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            var authTicket = new AuthenticationTicket(new ClaimsPrincipal(),
                new AuthenticationProperties(), JwtBearerDefaults.AuthenticationScheme);

            return Task.FromResult(AuthenticateResult.Success(authTicket));
        }

        public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy,
            AuthenticateResult authenticationResult, HttpContext context, object resource)
        {
            return Task.FromResult(PolicyAuthorizationResult.Success());
        }
    }
}
