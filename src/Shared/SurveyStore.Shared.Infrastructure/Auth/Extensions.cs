﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Infrastructure.Auth
{
    public static class Extensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IList<IModule> modules,
            Action<JwtBearerOptions> optionsFactory = null)
        {
            var options = services.GetOptions<AuthOptions>("auth");
            services.AddSingleton<IAuthManager, AuthManager>();
            if (options.AuthenticationDisabled)
            {
                services.AddSingleton<IPolicyEvaluator, DisabledAuthenticationPolicyEvaluator>();
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                RequireAudience = options.RequireAudience,
                ValidIssuer = options.ValidIssuer,
                ValidIssuers = options.ValidIssuers,
                ValidateIssuer = options.ValidateIssuer,
                ValidAudience = options.ValidAudience,
                ValidAudiences = options.ValidAudiences,
                ValidateAudience = options.ValidateAudience,
                ValidateActor = options.ValidateActor,
                ValidateLifetime = options.ValidateLifetime,
                ValidateTokenReplay = options.ValidateTokenReplay,
                ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
                SaveSigninToken = options.SaveSigninToken,
                RequireExpirationTime = options.RequireExpirationTime,
                RequireSignedTokens = options.RequireSignedTokens,
                ClockSkew = TimeSpan.Zero

            };
            if (string.IsNullOrWhiteSpace(options.IssuerSigningKey))
            {
                throw new ArgumentException("Missing issuer signing key.", nameof(options.IssuerSigningKey));
            }

            if (!string.IsNullOrWhiteSpace(options.AuthenticationType))
            {
                tokenValidationParameters.AuthenticationType = options.AuthenticationType;
            }

            var rawKey = Encoding.UTF8.GetBytes(options.IssuerSigningKey);
            tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(rawKey);
            if (!string.IsNullOrWhiteSpace(options.NameClaimType))
            {
                tokenValidationParameters.NameClaimType = options.NameClaimType;
            }

            if (!string.IsNullOrWhiteSpace(options.RoleClaimType))
            {
                tokenValidationParameters.RoleClaimType = options.RoleClaimType;
            }

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.Authority = options.Authority;
                o.Audience = options.Audience;
                o.MetadataAddress = options.MetadataAddress;
                o.SaveToken = options.SaveToken;
                o.RefreshOnIssuerKeyNotFound = options.RefreshOnIssuerKeyNotFound;
                o.RequireHttpsMetadata = options.RequireHttpsMetadata;
                o.IncludeErrorDetails = options.IncludeErrorDetails;
                o.TokenValidationParameters = tokenValidationParameters;
                if (!string.IsNullOrWhiteSpace(o.Challenge))
                {
                    o.Challenge = options.Challenge;
                }

                optionsFactory?.Invoke(o);
            });

            services.AddSingleton(options);
            services.AddSingleton(tokenValidationParameters);
            var policies = modules?.SelectMany(m => m.Policies ?? Enumerable.Empty<string>()) ??
                Enumerable.Empty<string>();
            services.AddAuthorization(auth =>
            {
                foreach (var policy in policies)
                {
                    auth.AddPolicy(policy, x => x.RequireClaim("permission", policy));
                }
            });

            return services;
        }
    }
}
