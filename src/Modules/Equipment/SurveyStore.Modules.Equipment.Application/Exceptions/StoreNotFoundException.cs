using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Application.Exceptions
{
    public class StoreNotFoundException : SurveyStoreException
    {
        public string Name { get; }
        public StoreNotFoundException(string name)
            : base($"Store with name '{name}' was not found.")
        {
            Name = name;
        }
    }
}
