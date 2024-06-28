using System;
using System.Xml.Linq;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class StoreNotFoundException : SurveyStoreException
    {
        public Guid Id { get; }
        public string Name { get; }

        public StoreNotFoundException(Guid id)
            : base($"Store with id '{id}' was not found.")
        {
            Id = id;
        }
        public StoreNotFoundException(string name)
            : base($"Store with name '{name}' was not found.")
        {
            Name = name;
        }
    }
}
