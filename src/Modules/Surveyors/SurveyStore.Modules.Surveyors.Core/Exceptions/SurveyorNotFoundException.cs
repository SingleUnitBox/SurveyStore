using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Surveyors.Core.Exceptions
{
    public class SurveyorNotFoundException : SurveyStoreException
    {
        public string Email { get; }
        public SurveyorNotFoundException(string email)
            : base($"Surveyor with email '{email}' was not found.")
        {
            Email = email;
        }
    }
}
