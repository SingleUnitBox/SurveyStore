using System.Collections.Generic;
using SurveyStore.Shared.Infrastructure.Auth;
using SurveyStore.Shared.Infrastructure.Time;

namespace SurveyStore.Shared.Tests
{
    public static class AuthHelper
    {
        private static readonly AuthManager AuthManager;

        static AuthHelper()
        {
            var options = OptionsHelper.GetOptions<AuthOptions>("auth");
            AuthManager = new AuthManager(options, new ClockUtc());
        }

        public static string GenerateJwt(string userId, IDictionary<string, IEnumerable<string>> claims, 
            string role = null, string audience = null)
            => AuthManager.CreateToken(userId, role, audience, claims).AccessToken;
    }
}
