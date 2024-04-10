using SurveyStore.Shared.Abstractions.Auth;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Users.Core.Commands
{
    public record SignIn(string Email, string Password) : ICommand<JsonWebToken>;
}
