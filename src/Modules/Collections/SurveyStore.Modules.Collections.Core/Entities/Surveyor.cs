using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Surveyor
    {
        public SurveyorId Id { get; set; }
        public string FullName { get; set; }
    }
}
