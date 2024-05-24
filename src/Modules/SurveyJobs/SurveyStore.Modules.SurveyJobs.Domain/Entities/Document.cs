using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class Document
    {
        public DocumentId Id { get; private set; }
        public DocumentTypes DocumentType { get; private set; }
        public string Link { get; private set; }
    }
}
