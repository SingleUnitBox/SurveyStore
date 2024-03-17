using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Surveyors.Core.Entities;

namespace SurveyStore.Modules.Surveyors.Core.Repositories
{
    public interface ISurveyorRepository
    {
        Task<Surveyor> GetByIdAsync(Guid id);
        Task<Surveyor> GetByEmailAsync(string email);
        Task<IReadOnlyCollection<Surveyor>> BrowseAsync();
        Task AddAsync(Surveyor surveyor);
        Task UpdateAsync(Surveyor surveyor);
        Task DeleteAsync(Surveyor surveyor);
    }
}
