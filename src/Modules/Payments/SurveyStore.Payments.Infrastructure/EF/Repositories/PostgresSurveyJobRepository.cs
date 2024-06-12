using SurveyStore.Modules.Payments.Domain.Entities;
using SurveyStore.Modules.Payments.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Payments.Infrastructure.EF.Repositories
{
    public class PostgresSurveyJobRepository : ISurveyJobRepository
    {
        public Task AddAsync(SurveyJob surveyJob)
        {
            throw new NotImplementedException();
        }

        public Task<SurveyJob> GetByIdAsync(AggregateId Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SurveyJob surveyJob)
        {
            throw new NotImplementedException();
        }
    }
}
