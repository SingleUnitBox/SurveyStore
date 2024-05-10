using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal sealed class PostgresKitCollectionRepository : IKitCollectionRepository
    {
        public Task<KitCollection> GetFreeByKitAsync(AggregateId kitId)
        {
            throw new NotImplementedException();
        }

        public Task<KitCollection> GetOpenByKitAsync(AggregateId kitId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(KitCollection kitCollection)
        {
            throw new NotImplementedException();
        }
    }
}
