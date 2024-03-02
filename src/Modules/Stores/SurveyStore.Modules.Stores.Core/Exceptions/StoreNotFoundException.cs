using Microsoft.AspNetCore.Identity;
using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Exceptions
{
    public class StoreNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public StoreNotFoundException(Guid id)
            : base($"Store with id '{id}' was not found.")
        {
            Id = id;
        }
    }
}
