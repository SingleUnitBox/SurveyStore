using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Repositories
{
    public class PostgresSurveyorRepository : ISurveyorRepository
    {
        public Task<Surveyor> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Surveyor> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Surveyor>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Surveyor surveyor)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Surveyor surveyor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Surveyor surveyor)
        {
            throw new NotImplementedException();
        }
    }
}
