using SurveyStore.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Core.Exceptions
{
    public class StoreAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public StoreAlreadyExistsException(Guid id)
            : base($"Store with id '{id}' already exists.")
        {
            Id = id;
        }
    }
}
