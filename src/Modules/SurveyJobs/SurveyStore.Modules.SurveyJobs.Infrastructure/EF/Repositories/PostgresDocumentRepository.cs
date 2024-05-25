using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Repositories
{
    internal sealed class PostgresDocumentRepository : IDocumentRepository
    {
        private readonly DbSet<Document> _documents;
        private readonly SurveyJobsDbContext _dbContext;

        public PostgresDocumentRepository(SurveyJobsDbContext dbContext)
        {
            _documents = dbContext.Documents;
            _dbContext = dbContext;
        }

        public async Task AddAsync(Document document)
        {
            await _documents.AddAsync(document);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Document document)
        {
            _documents.Update(document);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyCollection<Document>> BrowseAsync()
            => await _documents.ToListAsync();

        public Task<Document> GetByIdAsync(DocumentId id)
            => _documents
                .Include(d => d.SurveyJob)
                .FirstOrDefaultAsync(d => d.Id == id);
    }
}
