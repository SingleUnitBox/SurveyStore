using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyStore.Shared.Infrastructure.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly static Dictionary<string, IEnumerable<string>> EmptyClaims = new();
        private readonly AuthOptions _options;
        private readonly IClock _clock;
        private readonly SigningCredentials _signingCredentials;
        private readonly string _issuer;
        public AuthManager(AuthOptions options, IClock clock)
        {
            _options = options;
            _clock = clock;
            _issuer = options.Issuer;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.IssuerSigningKey)),
                SecurityAlgorithms.HmacSha256);
        }

        public JsonWebToken CreateToken(string userId, string role, string audience, IDictionary<string, IEnumerable<string>> claims)
        {
            throw new NotImplementedException();
        }
    }
}
