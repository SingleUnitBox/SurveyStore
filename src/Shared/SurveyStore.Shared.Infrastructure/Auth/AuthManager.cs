using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Windows.Markup;

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
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User id claim (subject) cannot be empty", nameof(userId));
            }

            var now = _clock.Current();
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeMilliseconds().ToString())
            };

            if (!string.IsNullOrWhiteSpace(role))
            {
                jwtClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            if (!string.IsNullOrWhiteSpace(audience))
            {
                jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Aud, audience));
            }

            if (claims.Any() is true)
            {
                var customClaims = new List<Claim>();
                foreach (var (claim, values) in claims)
                {
                    customClaims.AddRange(values.Select(v => new Claim(claim, v)));
                }

                jwtClaims.AddRange(customClaims);
            }

            var expires = now.Add(_options.Expiry);
            var jwt = new JwtSecurityToken(_issuer, claims: jwtClaims, notBefore: now, expires: expires,
                signingCredentials: _signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JsonWebToken
            {
                AccessToken = token,
                RefreshToken = string.Empty,
                Expires = new DateTimeOffset(expires).ToUnixTimeMilliseconds(),
                Id = userId,
                Role = role ?? string.Empty,
                Claims = claims ?? EmptyClaims,
            };
        }
    }
}
