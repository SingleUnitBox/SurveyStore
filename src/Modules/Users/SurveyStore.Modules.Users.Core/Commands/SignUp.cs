using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Users.Core.Commands
{
    public record SignUp(string Email, string Password, string Role,
        Dictionary<string, IEnumerable<string>> Claims) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
