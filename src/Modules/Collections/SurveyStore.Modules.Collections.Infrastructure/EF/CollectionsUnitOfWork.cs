using SurveyStore.Shared.Infrastructure.Postgres;

namespace SurveyStore.Modules.Collections.Infrastructure.EF
{
    internal class CollectionsUnitOfWork : PostgresUnitOfWork<CollectionsDbContext>, ICollectionsUnitOfWork
    {
        public CollectionsUnitOfWork(CollectionsDbContext dbContext) : base(dbContext)
        {
        }
    }
}