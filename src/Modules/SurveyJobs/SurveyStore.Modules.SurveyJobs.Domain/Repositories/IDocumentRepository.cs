using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Domain.Repositories
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task<Document> GetByIdAsync(DocumentId id);
        Task<IReadOnlyCollection<Document>> BrowseAsync();
    }
}