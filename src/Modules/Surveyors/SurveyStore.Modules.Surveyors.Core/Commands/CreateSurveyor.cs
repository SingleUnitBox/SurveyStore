using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Surveyors.Core.Commands
{
    public record CreateSurveyor(string Email, string FirstName, string Surname, string Position) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

}
