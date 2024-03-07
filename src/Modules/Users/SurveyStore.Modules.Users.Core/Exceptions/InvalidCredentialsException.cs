using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Exceptions
{
    public class InvalidCredentialsException : SurveyStoreException
    {
        public InvalidCredentialsException()
            : base($"Invalid credentials.")
        {
        }
    }
}
