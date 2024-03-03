using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Shared.Abstractions.Auth
{
    public record JsonWebToken(string AccessToken, string RefreshToken, long Expires, string Id, string Role, string Email,
        IDictionary<string, IEnumerable<string>> claims);
}
