using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Exceptions
{
    public class EmailInUseException : SurveyStoreException
    {
        public string Email { get; }
        public EmailInUseException(string email)
            : base($"Email '{email}' is already in use.")
        {
            Email = email;
        }
    }
}
