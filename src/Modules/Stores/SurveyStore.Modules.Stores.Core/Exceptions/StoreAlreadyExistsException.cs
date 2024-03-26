using SurveyStore.Shared.Abstractions.Exceptions;
using System;

namespace SurveyStore.Modules.Stores.Core.Exceptions
{
    public class StoreAlreadyExistsException : SurveyStoreException
    {
        public Guid Id { get; }
        public string Name { get; }
        public StoreAlreadyExistsException(Guid id)
            : base($"Store with id '{id}' already exists.")
        {
            Id = id;
        }

        public StoreAlreadyExistsException(string name)
            : base($"Store with name '{name}' already exists.")
        {
            Name = name;
        }
    }
}
