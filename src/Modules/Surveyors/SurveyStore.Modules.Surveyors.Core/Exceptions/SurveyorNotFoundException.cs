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
        public Guid Id { get; }
        public string Email { get; }

        public SurveyorNotFoundException(Guid id)
            : base($"Surveyor with id '{id}' was not found.")
        {
            Id = id;
        }

        public SurveyorNotFoundException(string email)
            : base($"Surveyor with email '{email}' was not found.")
        {
            Email = email;
        }
    }
}
