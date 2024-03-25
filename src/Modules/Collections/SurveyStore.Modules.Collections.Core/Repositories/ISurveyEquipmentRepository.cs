using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Core.Entities;

namespace SurveyStore.Modules.Collections.Core.Repositories
{
    public interface ISurveyEquipmentRepository
    {
        Task<SurveyEquipment> GetByIdAsync(Guid id);
        Task<SurveyEquipment> GetBySerialNumberAsync(string serialNumber);
        Task<IReadOnlyCollection<SurveyEquipment>> BrowseAsync();
        Task AddAsync(SurveyEquipment equipment);
        Task UpdateAsync(SurveyEquipment equipment);
        Task DeleteAsync(SurveyEquipment equipment);
    }
}
