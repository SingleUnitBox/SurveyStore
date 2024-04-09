using System;
using System.Threading.Tasks;
using SurveyStore.Shared.Infrastructure.Postgres;

namespace SurveyStore.Modules.Collections.Infrastructure.EF
{
    internal class CollectionsUnitOfWork : PostgresUnitOfWork<CollectionsDbContext>, ICollectionsUnitOfWork
    {
        public Task ExecuteAsync(Func<Task> action)
        {
            throw new NotImplementedException();
        }

        public CollectionsUnitOfWork(CollectionsDbContext dbContext) : base(dbContext)
        {
        }
    }
}